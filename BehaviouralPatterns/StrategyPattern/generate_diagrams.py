"""
Generates two UML-style diagrams for the Strategy pattern matching the
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


def arrow_h(draw, x1, y, x2, dashed=False):
    """Horizontal arrow with open arrowhead."""
    if dashed:
        dash, gap = 14, 8
        length = abs(x2 - x1)
        sx = min(x1, x2)
        for i in range(0, int(length), dash + gap):
            draw.line([(sx + i, y), (sx + min(i + dash, length), y)],
                      fill=FG, width=LINE_W)
    else:
        draw.line([(x1, y), (x2, y)], fill=FG, width=LINE_W)

    tip = x2
    if x2 > x1:
        draw.polygon([(tip, y), (tip - 16, y - 8), (tip - 16, y + 8)], fill=FG)
    else:
        draw.polygon([(tip, y), (tip + 16, y - 8), (tip + 16, y + 8)], fill=FG)


def arrow_up(draw, x, y_from, y_to):
    draw.line([(x, y_from), (x, y_to)], fill=FG, width=LINE_W)
    draw.polygon([(x, y_to), (x - 10, y_to + 18), (x + 10, y_to + 18)], fill=FG)


def diamond(draw, x, y):
    s = 12
    draw.polygon([(x, y - s), (x + s, y), (x, y + s), (x - s, y)], fill=FG)


# ── Diagram 1: strategy_pattern_diagram.jpg ──────────────────────────────────
#
#  Context  ◆────────►  Strategy
#                           ↑
#              ┌────────────┼────────────┐
#        ConcreteA    ConcreteB    ConcreteC

def make_pattern_diagram():
    img, draw = make_canvas()
    bold, normal = load_fonts()

    # Context (left)
    CX, CY, CW = 80, 340, 420
    ch = uml_box(draw, CX, CY, CW, bold, normal,
                 title="Context",
                 fields=["strategy"],
                 methods=["sort()"])

    # Strategy interface (right)
    SX, SY, SW = 780, 340, 420
    sh = uml_box(draw, SX, SY, SW, bold, normal,
                 title="Strategy",
                 methods=["sort()"])

    # Association line: Context ◆──► Strategy
    line_y = CY + ch // 2
    arrow_h(draw, CX + CW, line_y, SX)
    diamond(draw, CX + CW, line_y)

    # Three concrete strategies at the bottom
    boxes = [
        ("ConcreteA", 300),
        ("ConcreteB", 710),
        ("ConcreteC", 1120),
    ]
    BOT_Y = 720
    BOX_W = 300

    for title, bx in boxes:
        uml_box(draw, bx, BOT_Y, BOX_W, bold, normal,
                title=title, methods=["sort()"])

    # Inheritance tree
    s_mid_x  = SX + SW // 2
    s_bot_y  = SY + sh
    join_y   = BOT_Y - 60

    cx_list = [bx + BOX_W // 2 for _, bx in boxes]
    draw.line([(cx_list[0], join_y), (cx_list[-1], join_y)], fill=FG, width=LINE_W)
    for cx in cx_list:
        draw.line([(cx, BOT_Y), (cx, join_y)], fill=FG, width=LINE_W)
    arrow_up(draw, s_mid_x, s_bot_y, join_y)

    out = os.path.join(SCRIPT_DIR, "strategy_pattern_diagram.jpg")
    img.save(out, "JPEG", quality=95, dpi=(96, 96))
    print(f"Saved {out}")


# ── Diagram 2: class_diagram.jpg ─────────────────────────────────────────────
#
#  Sorter  ◆────────►  «interface»
#                       ISortStrategy
#                           ↑
#              ┌────────────┼────────────┐
#         BubbleSort   QuickSort    MergeSort

def make_class_diagram():
    img, draw = make_canvas()
    bold, normal = load_fonts()

    # Sorter (left)
    SRX, SRY, SRW = 80, 320, 380
    srh = uml_box(draw, SRX, SRY, SRW, bold, normal,
                  title="Sorter",
                  fields=["strategy"],
                  methods=["sort(data)"])

    # ISortStrategy interface (right)
    ISX, ISY, ISW = 760, 320, 420
    ish = uml_box(draw, ISX, ISY, ISW, bold, normal,
                  title="ISortStrategy",
                  stereotype="«interface»",
                  methods=["sort(data)"])

    # Dashed association with diamond
    line_y = SRY + srh // 2
    arrow_h(draw, SRX + SRW, line_y, ISX, dashed=True)
    diamond(draw, SRX + SRW, line_y)

    # Three concrete sort classes
    boxes = [
        ("BubbleSort", 260),
        ("QuickSort",  680),
        ("MergeSort", 1100),
    ]
    BOT_Y = 720
    BOX_W = 300

    for title, bx in boxes:
        uml_box(draw, bx, BOT_Y, BOX_W, bold, normal,
                title=title, methods=["sort(data)"])

    # Inheritance tree
    is_mid_x = ISX + ISW // 2
    is_bot_y = ISY + ish
    join_y   = BOT_Y - 60

    cx_list = [bx + BOX_W // 2 for _, bx in boxes]
    draw.line([(cx_list[0], join_y), (cx_list[-1], join_y)], fill=FG, width=LINE_W)
    for cx in cx_list:
        draw.line([(cx, BOT_Y), (cx, join_y)], fill=FG, width=LINE_W)
    arrow_up(draw, is_mid_x, is_bot_y, join_y)

    out = os.path.join(SCRIPT_DIR, "class_diagram.jpg")
    img.save(out, "JPEG", quality=95, dpi=(96, 96))
    print(f"Saved {out}")


if __name__ == "__main__":
    make_pattern_diagram()
    make_class_diagram()
    print("Done.")
