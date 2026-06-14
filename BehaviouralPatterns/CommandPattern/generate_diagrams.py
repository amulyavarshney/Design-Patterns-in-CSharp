"""
Generates two UML-style diagrams for the Command pattern matching the
existing repo style (white background, rounded boxes, bold titles).
"""

from PIL import Image, ImageDraw, ImageFont
import os

W, H   = 1620, 1080
BG     = (255, 255, 255)
FG     = (0, 0, 0)
LINE_W = 3
RADIUS = 20

SCRIPT_DIR = os.path.dirname(os.path.abspath(__file__))


def make_canvas():
    img  = Image.new("RGB", (W, H), BG)
    draw = ImageDraw.Draw(img)
    return img, draw


def load_fonts():
    candidates = [
        "/System/Library/Fonts/Helvetica.ttc",
        "/Library/Fonts/Arial.ttf",
        "/System/Library/Fonts/SFNSText.otf",
    ]
    bold = normal = None
    for p in candidates:
        try:
            bold   = ImageFont.truetype(p, 38)
            normal = ImageFont.truetype(p, 30)
            break
        except Exception:
            pass
    if bold is None:
        bold = normal = ImageFont.load_default()
    return bold, normal


def text_w(draw, text, font):
    bb = draw.textbbox((0, 0), text, font=font)
    return bb[2] - bb[0]


def uml_box(draw, x, y, w, bold, normal,
            title, stereotype=None, fields=None, methods=None):
    """Draw a UML box; returns total height."""
    fields  = fields  or []
    methods = methods or []
    LPAD    = 20
    line_h  = 36

    title_h   = (16 + 38 + 16) + ((24 + 6) if stereotype else 0)
    fields_h  = (len(fields)  * line_h + 20) if fields  else 0
    methods_h = (len(methods) * line_h + 20) if methods else 0
    total_h   = title_h + fields_h + methods_h

    draw.rounded_rectangle([x, y, x + w, y + total_h],
                           radius=RADIUS, outline=FG, width=LINE_W)

    ty = y
    if stereotype:
        sw = text_w(draw, stereotype, normal)
        draw.text((x + (w - sw) // 2, ty + 14), stereotype, fill=FG, font=normal)
        ty += 24 + 6

    tw = text_w(draw, title, bold)
    draw.text((x + (w - tw) // 2, ty + 16), title, fill=FG, font=bold)

    div1_y = y + title_h
    draw.line([(x, div1_y), (x + w, div1_y)], fill=FG, width=LINE_W)

    if fields:
        fy = div1_y + 12
        for f in fields:
            draw.text((x + LPAD, fy), f, fill=FG, font=normal)
            fy += line_h
        if methods:
            div2_y = div1_y + fields_h
            draw.line([(x, div2_y), (x + w, div2_y)], fill=FG, width=LINE_W)

    if methods:
        my = div1_y + fields_h + 12
        for m in methods:
            draw.text((x + LPAD, my), m, fill=FG, font=normal)
            my += line_h

    return total_h


def arrow_h(draw, x1, y, x2, dashed=False):
    """Horizontal arrow with open arrowhead pointing right."""
    if dashed:
        dash, gap, length = 14, 8, abs(x2 - x1)
        sx = min(x1, x2)
        for i in range(0, int(length), dash + gap):
            draw.line([(sx + i, y), (sx + min(i + dash, length), y)],
                      fill=FG, width=LINE_W)
    else:
        draw.line([(x1, y), (x2, y)], fill=FG, width=LINE_W)
    draw.polygon([(x2, y), (x2 - 16, y - 8), (x2 - 16, y + 8)], fill=FG)


def arrow_up(draw, x, y_from, y_to):
    draw.line([(x, y_from), (x, y_to)], fill=FG, width=LINE_W)
    draw.polygon([(x, y_to), (x - 10, y_to + 18), (x + 10, y_to + 18)], fill=FG)


def diamond(draw, x, y):
    s = 12
    draw.polygon([(x, y - s), (x + s, y), (x, y + s), (x - s, y)], fill=FG)


# ── Diagram 1: command_pattern_diagram.jpg ────────────────────────────────────
#
#  Invoker ──► «interface»Command   Receiver
#                    ↑
#            ┌───────┴───────┐
#       ConcreteA       ConcreteB

def make_pattern_diagram():
    img, draw = make_canvas()
    bold, normal = load_fonts()

    # Invoker — left
    IVX, IVY, IVW = 80, 300, 340
    ivh = uml_box(draw, IVX, IVY, IVW, bold, normal,
                  title="Invoker",
                  fields=["command"],
                  methods=["pressButton()"])

    # Command interface — centre-left
    CX, CY, CW = 560, 300, 380
    ch = uml_box(draw, CX, CY, CW, bold, normal,
                 title="Command",
                 stereotype="«interface»",
                 methods=["execute()", "undo()"])

    # Receiver — far right
    RX, RY, RW = 1360, 300, 240
    rh = uml_box(draw, RX, RY, RW, bold, normal,
                 title="Receiver",
                 methods=["action()"])

    # Invoker ──► Command (dashed: Invoker uses Command interface)
    iv_mid_y = IVY + ivh // 2
    arrow_h(draw, IVX + IVW, iv_mid_y, CX, dashed=True)

    # ConcreteCommandA — bottom left
    CAW = 320
    GAP = 160
    CAX = 300
    CAY = CY + ch + 220
    cah = uml_box(draw, CAX, CAY, CAW, bold, normal,
                  title="ConcreteCommandA",
                  methods=["execute()", "undo()"])

    # ConcreteCommandB — bottom right
    CBX = CAX + CAW + GAP
    CBY = CAY
    uml_box(draw, CBX, CBY, CAW, bold, normal,
            title="ConcreteCommandB",
            methods=["execute()", "undo()"])

    # Inheritance tree
    c_mid_x = CX + CW // 2
    c_bot_y = CY + ch
    join_y  = CAY - 60
    ca_cx   = CAX + CAW // 2
    cb_cx   = CBX + CAW // 2

    draw.line([(ca_cx, CAY), (ca_cx, join_y)], fill=FG, width=LINE_W)
    draw.line([(cb_cx, CBY), (cb_cx, join_y)], fill=FG, width=LINE_W)
    draw.line([(ca_cx, join_y), (cb_cx, join_y)], fill=FG, width=LINE_W)
    arrow_up(draw, c_mid_x, c_bot_y, join_y)

    # ConcreteCommandB ──► Receiver (dashed)
    ca_mid_y = CAY + cah // 2
    arrow_h(draw, CBX + CAW, ca_mid_y, RX, dashed=True)

    out = os.path.join(SCRIPT_DIR, "command_pattern_diagram.jpg")
    img.save(out, "JPEG", quality=95, dpi=(96, 96))
    print(f"Saved {out}")


# ── Diagram 2: class_diagram.jpg ─────────────────────────────────────────────
#
#  RemoteControl ──► «interface»ICommand   Light
#                          ↑
#                  ┌───────┴───────┐
#          LightOnCommand   LightOffCommand

def make_class_diagram():
    img, draw = make_canvas()
    bold, normal = load_fonts()

    # RemoteControl — left
    RCX, RCY, RCW = 60, 280, 360
    rch = uml_box(draw, RCX, RCY, RCW, bold, normal,
                  title="RemoteControl",
                  fields=["lastCommand"],
                  methods=["pressButton(cmd)",
                           "pressUndo()"])

    # ICommand interface — centre
    ICX, ICY, ICW = 560, 280, 380
    ich = uml_box(draw, ICX, ICY, ICW, bold, normal,
                  title="ICommand",
                  stereotype="«interface»",
                  methods=["execute()", "undo()"])

    # Light receiver — far right
    LX, LY, LW = 1360, 280, 240
    lh = uml_box(draw, LX, LY, LW, bold, normal,
                 title="Light",
                 fields=["name"],
                 methods=["turnOn()", "turnOff()"])

    # RemoteControl ──► ICommand (dashed)
    rc_mid_y = RCY + rch // 2
    arrow_h(draw, RCX + RCW, rc_mid_y, ICX, dashed=True)

    # LightOnCommand — bottom left
    CCW = 360
    GAP = 120
    LOX = 260
    LOY = ICY + ich + 220
    loh = uml_box(draw, LOX, LOY, CCW, bold, normal,
                  title="LightOnCommand",
                  fields=["light"],
                  methods=["execute()", "undo()"])

    # LightOffCommand — bottom right
    LFX = LOX + CCW + GAP
    LFY = LOY
    uml_box(draw, LFX, LFY, CCW, bold, normal,
            title="LightOffCommand",
            fields=["light"],
            methods=["execute()", "undo()"])

    # Inheritance tree
    ic_mid_x = ICX + ICW // 2
    ic_bot_y = ICY + ich
    join_y   = LOY - 60
    lo_cx    = LOX + CCW // 2
    lf_cx    = LFX + CCW // 2

    draw.line([(lo_cx, LOY), (lo_cx, join_y)], fill=FG, width=LINE_W)
    draw.line([(lf_cx, LFY), (lf_cx, join_y)], fill=FG, width=LINE_W)
    draw.line([(lo_cx, join_y), (lf_cx, join_y)], fill=FG, width=LINE_W)
    arrow_up(draw, ic_mid_x, ic_bot_y, join_y)

    # LightOffCommand ──► Light (dashed)
    cmd_mid_y = LOY + loh // 2
    arrow_h(draw, LFX + CCW, cmd_mid_y, LX, dashed=True)

    out = os.path.join(SCRIPT_DIR, "class_diagram.jpg")
    img.save(out, "JPEG", quality=95, dpi=(96, 96))
    print(f"Saved {out}")


if __name__ == "__main__":
    make_pattern_diagram()
    make_class_diagram()
    print("Done.")
