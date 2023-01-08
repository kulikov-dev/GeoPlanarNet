namespace GeoPlanarNet.Enums
{
    /// <summary>
    /// Figures overlapping enum
    /// </summary>
    public enum FiguresOverlapping
    {
        /// <summary>
        /// Figure 2 inside figure 1
        /// </summary>
        Figure2InsideFigure1,
        
        /// <summary>
        /// Figure 1 inside figure 2
        /// </summary>
        Figure1InsideFigure2,

        /// <summary>
        /// Figures intersects
        /// </summary>
        Intersects,

        /// <summary>
        /// Figures in touch
        /// </summary>
        InTouch,

        /// <summary>
        /// Figures don't overlap
        /// </summary>
        DoNotOverlap
    }
}