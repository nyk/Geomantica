using System;
using System.Collections.Generic;
using System.Text;

namespace Geomantica
{
    // <summary>Datatype that represents a geomantic figure</summary>
    public struct Figure
    {
        public Rune Rune { get; }

        // <summary>Initializes a new figure with a particular Geomantica.Rune value.</summary>
        // <see cref="Geomantica.Rune"/>
        // <param name="value">A Rune value of the figure</param>
        // <returns>An instantiated Geomantica.Figure object
        public Figure(Rune rune) : this()
        {
            Rune = rune;
        }

        // <summary>Overloaded + operator to conjugate two Geomantica.Figure objects.</summary>
        // <param name="prefix">The prefixed figure</param>
        // <param name="suffix">The suffixed figure</param>
        // <returns>A new Geomantica.Figure object</returns>
        public static Figure operator +(Figure prefix, Figure suffix)
        {
            // XOR the runes of the two figures and return new figure 
            // initialized with resulting rune value.
            var rune = prefix.Rune ^ suffix.Rune;
            return new Figure(rune);
        }

        // <summary>Overloaded bitwise complement operator (~) to get the complementary Geomantica.Figure object.</summary>
        // <para name="suffix">The Geomantica.Figure object on which the operator operates</param>
        // <returns>A new Geomantica.Figure object</returns>
        public static Figure operator ~(Figure suffix)
        {
            // Take the complement of the Rune, and subtract the first half of the byte,
            // then return a new figure initialized with the resulting rune value.
            var rune = ~suffix.Rune - 240;
            return new Figure(rune);
        }

        // <summary>Override the ToString() method to return the name of the rune/figure.
        public override string ToString() => $"{this.Rune.ToString()}";
    }
}
