"""
Generates two UML-style diagrams for the Template Method pattern matching the
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


def arrow_up(draw, x, y_from, y_to):
    """Vertical line with open upward arrowhead."""
    draw.line([(x, y_from), (x, y_to)], fill=FG, width=LINE_W)
    draw.polygon([(x, y_to), (x - 10, y_to + 18), (x + 10, y_to + 18)], fill=FG)


# ── Diagram 1: template_method_pattern_diagram.jpg ────────────────────────────
#
#        AbstractClass
#      generateReport()   ← template method
#       fetchData()       ← concrete step
#       formatData()      ← abstract hook
#           ↑
#     ┌─────┴─────┐
# ConcreteA   ConcreteB

def make_pattern_diagram():
    img, draw = make_canvas()
    bold, normal = load_fonts()

    # AbstractClass (top-centre)
    AW = 560
    AX = (W - AW) // 2
    AY = 160
    ah = uml_box(draw, AX, AY, AW, bold, normal,
                 title="AbstractClass",
                 stereotype="«abstract»",
                 methods=["generateReport()",
                          "fetchData()",
                          "formatData()"])

    # ConcreteA (bottom-left)
    CW = 380
    CAX = AX - 160
    CAY = AY + ah + 200
    uml_box(draw, CAX, CAY, CW, bold, normal,
            title="ConcreteA",
            methods=["formatData()"])

    # ConcreteB (bottom-right)
    CBX = AX + AW - CW + 160
    CBY = CAY
    uml_box(draw, CBX, CBY, CW, bold, normal,
            title="ConcreteB",
            methods=["formatData()"])

    # Inheritance tree
    a_mid_x = AX + AW // 2
    a_bot_y = AY + ah
    join_y  = CAY - 60

    ca_cx = CAX + CW // 2
    cb_cx = CBX + CW // 2

    draw.line([(ca_cx, CAY), (ca_cx, join_y)], fill=FG, width=LINE_W)
    draw.line([(cb_cx, CBY), (cb_cx, join_y)], fill=FG, width=LINE_W)
    draw.line([(ca_cx, join_y), (cb_cx, join_y)], fill=FG, width=LINE_W)
    arrow_up(draw, a_mid_x, a_bot_y, join_y)

    out = os.path.join(SCRIPT_DIR, "template_method_pattern_diagram.jpg")
    img.save(out, "JPEG", quality=95, dpi=(96, 96))
    print(f"Saved {out}")


# ── Diagram 2: class_diagram.jpg ─────────────────────────────────────────────
#
#       ReportGenerator
#      generateReport()   ← sealed template method
#       openFile()        ← private step
#       fetchData()       ← private step
#       formatData()      ← abstract hook
#       closeFile()       ← private step
#           ↑
#     ┌─────┴─────┐
#  CsvReport  HtmlReport

def make_class_diagram():
    img, draw = make_canvas()
    bold, normal = load_fonts()

    # ReportGenerator (top-centre)
    RW = 600
    RX = (W - RW) // 2
    RY = 120
    rh = uml_box(draw, RX, RY, RW, bold, normal,
                 title="ReportGenerator",
                 stereotype="«abstract»",
                 methods=["generateReport()",
                          "openFile()",
                          "fetchData()",
                          "formatData()",
                          "closeFile()"])

    # CsvReport (bottom-left)
    CW = 380
    CRX = RX - 100
    CRY = RY + rh + 200
    uml_box(draw, CRX, CRY, CW, bold, normal,
            title="CsvReport",
            methods=["formatData()"])

    # HtmlReport (bottom-right)
    HRX = RX + RW - CW + 100
    HRY = CRY
    uml_box(draw, HRX, HRY, CW, bold, normal,
            title="HtmlReport",
            methods=["formatData()"])

    # Inheritance tree
    r_mid_x = RX + RW // 2
    r_bot_y = RY + rh
    join_y  = CRY - 60

    cr_cx = CRX + CW // 2
    hr_cx = HRX + CW // 2

    draw.line([(cr_cx, CRY), (cr_cx, join_y)], fill=FG, width=LINE_W)
    draw.line([(hr_cx, HRY), (hr_cx, join_y)], fill=FG, width=LINE_W)
    draw.line([(cr_cx, join_y), (hr_cx, join_y)], fill=FG, width=LINE_W)
    arrow_up(draw, r_mid_x, r_bot_y, join_y)

    out = os.path.join(SCRIPT_DIR, "class_diagram.jpg")
    img.save(out, "JPEG", quality=95, dpi=(96, 96))
    print(f"Saved {out}")


if __name__ == "__main__":
    make_pattern_diagram()
    make_class_diagram()
    print("Done.")
