"""
Generates two UML-style diagrams for the Chain of Responsibility pattern
matching the existing repo style (white background, rounded boxes, bold titles).
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


def tw(draw, text, font):
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
        sw = tw(draw, stereotype, normal)
        draw.text((x + (w - sw) // 2, ty + 14), stereotype, fill=FG, font=normal)
        ty += 24 + 6

    t_w = tw(draw, title, bold)
    draw.text((x + (w - t_w) // 2, ty + 16), title, fill=FG, font=bold)

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


def arrow_right(draw, x1, y, x2):
    """Horizontal arrow with open arrowhead pointing right."""
    draw.line([(x1, y), (x2, y)], fill=FG, width=LINE_W)
    draw.polygon([(x2, y), (x2 - 16, y - 8), (x2 - 16, y + 8)], fill=FG)


def arrow_up(draw, x, y_from, y_to):
    """Vertical line with open upward arrowhead."""
    draw.line([(x, y_from), (x, y_to)], fill=FG, width=LINE_W)
    draw.polygon([(x, y_to), (x - 10, y_to + 18), (x + 10, y_to + 18)], fill=FG)


def self_arrow(draw, x, y, w, h, normal, label):
    """Small self-referencing arrow on the right side of a box (next reference)."""
    rx = x + w
    mid_y = y + h // 2
    offset = 40
    # line out to the right
    draw.line([(rx, mid_y), (rx + offset, mid_y)], fill=FG, width=LINE_W)
    # line down
    draw.line([(rx + offset, mid_y), (rx + offset, mid_y + offset)], fill=FG, width=LINE_W)
    # line back left with arrowhead
    draw.line([(rx + offset, mid_y + offset), (rx - 10, mid_y + offset)], fill=FG, width=LINE_W)
    draw.polygon([(rx - 10, mid_y + offset),
                  (rx - 10 + 16, mid_y + offset - 8),
                  (rx - 10 + 16, mid_y + offset + 8)], fill=FG)
    # label
    draw.text((rx + offset + 6, mid_y + 4), label, fill=FG, font=normal)


# ── Diagram 1: chain_of_responsibility_pattern_diagram.jpg ───────────────────
#
#   Top row:   Handler (abstract)
#   Bottom row: ConcreteA ──► ConcreteB
#   Both concretes inherit from Handler (arrows up)

def make_pattern_diagram():
    img, draw = make_canvas()
    bold, normal = load_fonts()

    BOX_W = 420

    # Abstract Handler — top centre
    AX = (W - BOX_W) // 2
    AY = 120
    ah = uml_box(draw, AX, AY, BOX_W, bold, normal,
                 title="Handler",
                 stereotype="«abstract»",
                 fields=["next: Handler"],
                 methods=["setNext(handler)",
                          "handle(request)"])

    # ConcreteHandlerA — bottom left
    CW  = 380
    GAP = 120
    CAX = AX - CW // 2 - GAP // 2
    CAY = AY + ah + 200
    cah = uml_box(draw, CAX, CAY, CW, bold, normal,
                  title="ConcreteHandlerA",
                  methods=["handle(request)"])

    # ConcreteHandlerB — bottom right
    CBX = AX + BOX_W - CW // 2 + GAP // 2
    CBY = CAY
    uml_box(draw, CBX, CBY, CW, bold, normal,
            title="ConcreteHandlerB",
            methods=["handle(request)"])

    # Inheritance tree
    a_mid_x  = AX + BOX_W // 2
    a_bot_y  = AY + ah
    join_y   = CAY - 60
    ca_cx    = CAX + CW // 2
    cb_cx    = CBX + CW // 2

    draw.line([(ca_cx, CAY), (ca_cx, join_y)], fill=FG, width=LINE_W)
    draw.line([(cb_cx, CBY), (cb_cx, join_y)], fill=FG, width=LINE_W)
    draw.line([(ca_cx, join_y), (cb_cx, join_y)], fill=FG, width=LINE_W)
    arrow_up(draw, a_mid_x, a_bot_y, join_y)

    # "next" horizontal arrow between the two concrete boxes (shows chaining)
    arrow_right(draw, CAX + CW, CAY + cah // 2, CBX)
    # label above the arrow
    mid_ax = CAX + CW + (CBX - CAX - CW) // 2
    draw.text((mid_ax - 20, CAY + cah // 2 - 36), "next", fill=FG, font=normal)

    out = os.path.join(SCRIPT_DIR, "chain_of_responsibility_pattern_diagram.jpg")
    img.save(out, "JPEG", quality=95, dpi=(96, 96))
    print(f"Saved {out}")


# ── Diagram 2: class_diagram.jpg ─────────────────────────────────────────────
#
#   Top row:   SupportHandler (abstract)
#   Bottom row: FrontDesk ──► Supervisor ──► Manager
#   All three inherit from SupportHandler

def make_class_diagram():
    img, draw = make_canvas()
    bold, normal = load_fonts()

    # Abstract SupportHandler — top centre
    AW = 500
    AX = (W - AW) // 2
    AY = 100
    ah = uml_box(draw, AX, AY, AW, bold, normal,
                 title="SupportHandler",
                 stereotype="«abstract»",
                 fields=["next: SupportHandler"],
                 methods=["setNext(handler)",
                          "handle(ticket)"])

    # Three concrete handlers — bottom row, evenly spaced
    CW  = 320
    GAP = 60
    total_w = 3 * CW + 2 * GAP
    row_x   = (W - total_w) // 2
    ROW_Y   = AY + ah + 200

    FX = row_x
    SX = row_x + CW + GAP
    MX = row_x + 2 * (CW + GAP)

    fh = uml_box(draw, FX, ROW_Y, CW, bold, normal,
                 title="FrontDesk",
                 methods=["handle(ticket)"])
    uml_box(draw, SX, ROW_Y, CW, bold, normal,
            title="Supervisor",
            methods=["handle(ticket)"])
    uml_box(draw, MX, ROW_Y, CW, bold, normal,
            title="Manager",
            methods=["handle(ticket)"])

    # Inheritance tree
    a_mid_x = AX + AW // 2
    a_bot_y = AY + ah
    join_y  = ROW_Y - 60

    fx_cx = FX + CW // 2
    sx_cx = SX + CW // 2
    mx_cx = MX + CW // 2

    draw.line([(fx_cx, ROW_Y), (fx_cx, join_y)], fill=FG, width=LINE_W)
    draw.line([(sx_cx, ROW_Y), (sx_cx, join_y)], fill=FG, width=LINE_W)
    draw.line([(mx_cx, ROW_Y), (mx_cx, join_y)], fill=FG, width=LINE_W)
    draw.line([(fx_cx, join_y), (mx_cx, join_y)], fill=FG, width=LINE_W)
    arrow_up(draw, a_mid_x, a_bot_y, join_y)

    # "next" arrows between the concrete boxes (shows the runtime chain)
    arrow_mid_y = ROW_Y + fh // 2
    arrow_right(draw, FX + CW, arrow_mid_y, SX)
    arrow_right(draw, SX + CW, arrow_mid_y, MX)

    label_y = arrow_mid_y - 36
    draw.text((FX + CW + (SX - FX - CW) // 2 - 20, label_y), "next", fill=FG, font=normal)
    draw.text((SX + CW + (MX - SX - CW) // 2 - 20, label_y), "next", fill=FG, font=normal)

    out = os.path.join(SCRIPT_DIR, "class_diagram.jpg")
    img.save(out, "JPEG", quality=95, dpi=(96, 96))
    print(f"Saved {out}")


if __name__ == "__main__":
    make_pattern_diagram()
    make_class_diagram()
    print("Done.")
