# Paint Integration Guide

Microsoft Paint is built into every Windows PC. APDocs Studio lets you open any image directly in Paint, edit it with precision, and bring the result back automatically.

---

## How to Open an Image in Paint

1. In APDocs Studio, right-click any page in the document list
2. Select "Edit with Paint"
3. Paint opens with your image loaded
4. Make your edits
5. Press `Ctrl+S` to save
6. APDocs Studio automatically reloads the edited image

---

## Rectangular Select & Cut

Use this to remove any rectangular area from an image.

```
1. In Paint's Home tab, click Select ? Rectangular selection
2. Click and drag to draw a box around the area to remove
3. Press Delete or Ctrl+X to cut it out
4. Set background color to white first for clean results
5. Press Ctrl+S to save
```

Tip: Right-click Color 2 and set it to white before cutting to ensure the removed area fills with white.

---

## Free-form Select

Use this to isolate any irregular shape.

```
1. Click Select ? Free-form selection
2. Draw around the exact shape you want to keep
3. Press Ctrl+C to copy the selection
4. Press Ctrl+N for a new blank canvas
5. Press Ctrl+V to paste your selection
6. Press Ctrl+S to save
```

---

## Remove a Watermark or Stamp

```
1. Right-click Color 2 in Paint ? set to white
2. Use Rectangular Select to draw a box around the watermark
3. Press Delete — the area fills with white
4. Press Ctrl+S to save
5. Back in APDocs Studio, export as a clean PDF
```

---

## Crop to a Specific Region

```
1. Use Rectangular Select to draw around the region you want to keep
2. Click Image ? Crop in the toolbar (or Ctrl+Shift+X on Windows 11)
3. Press Ctrl+S to save
4. APDocs Studio picks up the cropped image automatically
```

---

## Tips

- Always set Color 2 to white before cutting to avoid colored fill
- Use zoom in Paint (Ctrl+scroll) for precise selections on small areas
- Undo in Paint with Ctrl+Z before saving if you make a mistake
- APDocs Studio only reloads after you save in Paint
