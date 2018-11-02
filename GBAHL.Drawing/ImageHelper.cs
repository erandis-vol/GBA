﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;

namespace GBAHL.Drawing
{
    public static class ImageHelper
    {
        /// <summary>
        /// Returns a palette for this <see cref="Image"/> instance.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <returns></returns>
        /// <exception cref="FormatException">the image is not indexed.</exception>
        public static Palette GetPalette(this Image image)
        {
            // Make sure the image actually has a palette to grab
            if (!IsIndexed(image))
            {
                throw new FormatException("The image is not indexed.");
            }

            // Create the palette, converting the colors
            return new Palette(image.Palette.Entries.Select(x => x.ToColor2()));
        }

        /// <summary>
        /// Determines whether this <see cref="Image"/> is indexed.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <returns>true if the image is indexed; otherwise, false.</returns>
        public static bool IsIndexed(this Image image)
        {
            if (image == null)
                return false;

            return (image.PixelFormat & PixelFormat.Indexed) == PixelFormat.Indexed;
        }
    }
}