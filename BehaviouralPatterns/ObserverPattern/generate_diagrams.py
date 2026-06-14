"""
Generates two UML-style diagrams for the Observer pattern matching the existing
class_diagram.jpg / state_pattern_diagram.jpg visual style in this repo.
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
    bold = normal = small = None
    for p in candidates:
        try:
            bold   = ImageFont.truetype(p, 38)
            normal = ImageFont.truetype(p, 30)
            small  = ImageFont.truetype(p, 24)
            break
        except Exception:
            pass
    if bold is None:
        bold = normal = small = ImageFont.load_default()
    return bold, normal, small


def text_width(draw, text, font):
    bb = draw.textbbox((0, 0), text, font=font)
    return bb[2] - bb[0]


def uml_box(draw, x, y, w, bold, normal,
            title, stereotype=None, fields=None, methods=None):
    """
    Draw a UML box. Returns the total height used.
    stereotype : small italic label above the title (e.g. '«interface»')
    fields     : list of strings in the middle section
    methods    : list of strings in the bottom section
    """
    fields  = fields  or []
    methods = methods or []

    PAD  = 14   # horizontal padding for text
    LPAD = 20   # left padding

    # ── measure section heights ──────────────────────────────────────────────
    line_h = 36

    # title section height
    title_h = 16 + 38 + 16          # top-pad + font + bottom-pad
    if stereotype:
        title_h += 24 + 6           # small font + gap

    # fields section height
    fields_h = (len(fields) * line_h + 20) if fields else 0

    # methods section height
    methods_h = (len(methods) * line_h + 20) if methods else 0

    total_h = title_h + fields_h + methods_h

    # ── outer rounded rect ───────────────────────────────────────────────────
    draw.rounded_rectangle([x, y, x + w, y + total_h],
                           radius=RADIUS, outline=FG, width=LINE_W)

    # ── title section ────────────────────────────────────────────────────────
    ty = y
    if stereotype:
        sw = text_width(draw, stereotype, normal)
        draw.text((x + (w - sw) // 2, ty + 14), stereotype, fill=FG, font=normal)
        ty += 24 + 6

    tw = text_width(draw, title, bold)
    draw.text((x + (w - tw) // 2, ty + 16), title, fill=FG, font=bold)

    div1_y = y + title_h
    draw.line([(x, div1_y), (x + w, div1_y)], fill=FG, width=LINE_W)

    # ── fields section ───────────────────────────────────────────────────────
    if fields:
        fy = div1_y + 12
        for f in fields:
            draw.text((x + LPAD, fy), f, fill=FG, font=normal)
            fy += line_h

        if methods:
            div2_y = div1_y + fields_h
            draw.line([(x, div2_y), (x + w, div2_y)], fill=FG, width=LINE_W)

    # ── methods section ──────────────────────────────────────────────────────
    if methods:
        my = div1_y + fields_h + 12
        for m in methods:
            draw.text((x + LPAD, my), m, fill=FG, font=normal)
            my += line_h

    return total_h


def arrow_h(draw, x1, y, x2, dashed=False):
    """Horizontal arrow from (x1,y) to (x2,y) with open arrowhead pointing right."""
    if dashed:
        dash, gap = 14, 8
        length = abs(x2 - x1)
        sx = min(x1, x2)
        for i in range(0, int(length), dash + gap):
            draw.line([(sx + i, y), (sx + min(i + dash, length), y)],
                      fill=FG, width=LINE_W)
    else:
        draw.line([(x1, y), (x2, y)], fill=FG, width=LINE_W)

    # arrowhead direction
    if x2 > x1:
        tip = x2
        draw.polygon([(tip, y), (tip - 16, y - 8), (tip - 16, y + 8)], fill=FG)
    else:
        tip = x2
        draw.polygon([(tip, y), (tip + 16, y - 8), (tip + 16, y + 8)], fill=FG)


def arrow_up(draw, x, y_from, y_to):
    """Vertical line with open upward arrowhead at y_to."""
    draw.line([(x, y_from), (x, y_to)], fill=FG, width=LINE_W)
    draw.polygon([(x, y_to), (x - 10, y_to + 18), (x + 10, y_to + 18)], fill=FG)


def diamond(draw, x, y):
    """Small filled diamond centred at (x, y)."""
    s = 12
    draw.polygon([(x, y - s), (x + s, y), (x, y + s), (x - s, y)], fill=FG)


# ── Diagram 1: observer_pattern_diagram.jpg ──────────────────────────────────
#
#  Subject  ◆────────►  Observer
#                           ↑
#                    ┌──────┴──────┐
#              ConcreteObsA   ConcreteObsB

def make_pattern_diagram():
    img, draw = make_canvas()
    bold, normal, small = load_fonts()

    # Subject (left)
    SX, SY, SW = 100, 300, 480
    sh = uml_box(draw, SX, SY, SW, bold, normal,
                 title="Subject",
                 methods=["addObserver(o)",
                          "removeObserver(o)",
                          "notifyObservers()"])

    # Observer (right)
    OX, OY, OW = 820, 300, 420
    oh = uml_box(draw, OX, OY, OW, bold, normal,
                 title="Observer",
                 methods=["update()"])

    # Association line with diamond on Subject and arrowhead on Observer
    mid_sy = SY + sh // 2
    mid_oy = OY + oh // 2
    line_y = (mid_sy + mid_oy) // 2   # average (both horizontally level)
    arrow_h(draw, SX + SW, line_y, OX)
    diamond(draw, SX + SW, line_y)

    # ConcreteObserverA (bottom-left below Observer)
    CAX, CAY, CAW = 540, 720, 380
    uml_box(draw, CAX, CAY, CAW, bold, normal,
            title="ConcreteObsA",
            methods=["update()"])

    # ConcreteObserverB (bottom-right below Observer)
    CBX, CBY, CBW = 1000, 720, 380
    uml_box(draw, CBX, CBY, CBW, bold, normal,
            title="ConcreteObsB",
            methods=["update()"])

    # Inheritance tree: two legs → join bar → arrow up to Observer bottom
    obs_mid_x = OX + OW // 2
    obs_bot_y = OY + oh
    join_y    = CAY - 60

    ca_cx = CAX + CAW // 2
    cb_cx = CBX + CBW // 2

    draw.line([(ca_cx, CAY), (ca_cx, join_y)], fill=FG, width=LINE_W)
    draw.line([(cb_cx, CBY), (cb_cx, join_y)], fill=FG, width=LINE_W)
    draw.line([(ca_cx, join_y), (cb_cx, join_y)], fill=FG, width=LINE_W)
    arrow_up(draw, obs_mid_x, obs_bot_y, join_y)

    out = os.path.join(SCRIPT_DIR, "observer_pattern_diagram.jpg")
    img.save(out, "JPEG", quality=95, dpi=(96, 96))
    print(f"Saved {out}")


# ── Diagram 2: class_diagram.jpg ─────────────────────────────────────────────
#
#  Stock  ◆- - - - -►  «interface»
#                        IObserver
#                           ↑
#                    ┌──────┴──────┐
#               StockDisplay   MobileAlert

def make_class_diagram():
    img, draw = make_canvas()
    bold, normal, small = load_fonts()

    # Stock (left)
    SX, SY, SW = 80, 260, 460
    sh = uml_box(draw, SX, SY, SW, bold, normal,
                 title="Stock",
                 fields=["name: string", "price: float"],
                 methods=["addObserver(o)",
                          "removeObserver(o)",
                          "notifyObservers()"])

    # IObserver (right)
    IOX, IOY, IOW = 820, 260, 420
    ioh = uml_box(draw, IOX, IOY, IOW, bold, normal,
                  title="IObserver",
                  stereotype="«interface»",
                  methods=["update(name, price)"])

    # Dashed arrow with diamond
    line_y = SY + sh // 2
    arrow_h(draw, SX + SW, line_y, IOX, dashed=True)
    diamond(draw, SX + SW, line_y)

    # StockDisplay (bottom-left)
    SDX, SDY, SDW = 520, 730, 380
    uml_box(draw, SDX, SDY, SDW, bold, normal,
            title="StockDisplay",
            methods=["update(name, price)"])

    # MobileAlert (bottom-right)
    MAX2, MAY, MAW = 980, 730, 380
    uml_box(draw, MAX2, MAY, MAW, bold, normal,
            title="MobileAlert",
            methods=["update(name, price)"])

    # Inheritance tree
    io_mid_x = IOX + IOW // 2
    io_bot_y = IOY + ioh
    join_y   = SDY - 60

    sd_cx = SDX + SDW // 2
    ma_cx = MAX2 + MAW // 2

    draw.line([(sd_cx, SDY), (sd_cx, join_y)], fill=FG, width=LINE_W)
    draw.line([(ma_cx, MAY), (ma_cx, join_y)], fill=FG, width=LINE_W)
    draw.line([(sd_cx, join_y), (ma_cx, join_y)], fill=FG, width=LINE_W)
    arrow_up(draw, io_mid_x, io_bot_y, join_y)

    out = os.path.join(SCRIPT_DIR, "class_diagram.jpg")
    img.save(out, "JPEG", quality=95, dpi=(96, 96))
    print(f"Saved {out}")


if __name__ == "__main__":
    make_pattern_diagram()
    make_class_diagram()
    print("Done.")
