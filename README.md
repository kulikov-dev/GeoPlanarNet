# GeoPlanarNet
## A simple and small.NET library for computational planar geometry. 
The GeoPlanarNet library's primary function is manipulating basic geometrical primitives like points, lines, triangles, and rectangles in 2D space. Implemented both simple (like finding the intersection point of two lines) and complex (like checking if the point in the circle sector) methods. All methods have overloads to work with standart .NET graphics classes: Point, PointF, Rect, RectF.

Because readability and simplicity of the code were the key objectives, speed and robustness were not given top emphasis. Global tolerance property is used for proximity checking, not an exact robust algorithms.

### PointGeo:
* <b>DistanceTo</b> - Get distance between two points;
* <b>DistanceToLine</b> - Get shortest distance to the line;
* <b>DistanceToSegment</b> - Get shortest distance from point to the segment;
* <b>DistanceToRect</b> - Get shortest distance from point to the axis-oriented and given by arbitrary points rectangle;
* <b>DistanceToCircle</b> - Get shortest distance from the point to the circle;
* <b>DistanceToTriangle</b> - Get shortest distance from the point to the triangle;
* <b>DistanceToSurface</b> - Get shortest distance from point to the surface;
* <b>BelongsToSegment</b> - Check if the point belongs to the segment;
* <b>BelongsToLine</b> - Check if the point belongs to the line;
* <b>BelongsToCircle</b> - Check if a point belongs to a circle;
* <b>BelongsToCircleSector</b> - Check if the point belong to the specific circle sector;
* <b>BelongsToEllipse</b> - Check if the point belongs to the axis-parallel ellipse;
* <b>BelongsToEllipseSector</b> - Check if the point belong to the specific axis-parallel ellipse sector;
* <b>BelongsToTriangle</b> - Check if a point belongs to a triangle;
* <b>BelongsToRect</b> - Check if the point belongs to the axis-oriented rectangle;
* <b>BelongsToSurface</b> - Check if a point belongs to the surface;
* <b>GetClosestPointOnSegment</b> - Find the point on the segment closest to the given one;
* <b>GetClosestPointOnCircle</b> - Get closest point on the circle to the given point;
* <b>GetClosestPointOnEllipse</b> - Get closest point on the axis-parallel ellipse to the given point;
* <b>GetClosestPointOnTriangle</b> - Get closest point on the triangle to the given point;
* <b>GetClosestPointOnRect</b> - Get closest point on the axis-oriented and given by arbitrary points rectangle to the given point;
* <b>GetRelativeLocationSimple, GetRelativeLocation</b> - Get the point location relative to a segment;
* <b>GetRelativeLocationTriangle</b> - Get the point location relative to the triangle;
* <b>GetRelativeLocationCircle</b> - Get the point location relative to the circle;
* <b>GetRelativeLocationEllipse</b> - Get the point location relative to the axis-parallel ellipse;
* <b>GetRelativeLocationRect</b> - Get the point location relative to the axis-oriented and given by arbitrary points rectangle;
* <b>GetProjectionToLine</b> - Get projection from the point to the line;
* <b>HasProjectionToSegment</b> - Check if the point has projection to the segment;
* <b>GetProjectionToSegment</b> - Get projection point to the segment;
* <b>Equals</b> - Check if two points are equal;
* <b>IsCollinear</b> - Check if three points are collinear;
* <b>Rotate</b> - Rotate the point around the center point;
* <b>GetVectorProduct</b> - Calculate vector product between point and segment;
* <b>GetAngle</b> - Get axis-degree angle between two points;
* <b>MinDistanceToCurveLine</b> - Find the minimal distance from a curve to a point.

### SegmentGeo
* <b>Length</b> - Get segment length;
* <b>DistanceToPoint</b> - Get shortest distance from point to the segment;
* <b>DistanceToCircle</b> - Get shortest distance from the segment to the circle;
* <b>HasIntersection</b> - Check if two segments have intersection;
* <b>FindIntersection</b> - Find the intersection point between two segments;
* <b>HasSurfaceIntersection</b> - Check if the curve line and the segment has intersection;
* <b>FindSurfaceIntersection</b> - Find the intersection point between the segment and the surface;
* <b>HasRectIntersection</b> - Check if the rectangle and the segment has intersection;
* <b>FindRectIntersection</b> - Find the intersection point between the rectangle and the surface;
* <b>HasTriangleIntersection</b> - Check if the triangle and the segment has intersection;
* <b>FindTriangleIntersection</b> - Find the intersection point between the triangle and the surface;
* <b>BelongsToLine</b> - Check if the segment belongs to the line;
* <b>GetXAngleRadians</b> - Get the segment tilt angle relative to the X axis;
* <b>GetAngleRadians</b> - Get angle between two segments. Get angle between two segments with the common point;
* <b>IsBetweenAngles</b> - Check if the segment lays between start angle and end angle;
* <b>GetPointAwayFromStart</b> - Get the point away from the segment start point on the specified distance;
* <b>GetPointAwayFromEnd</b> - Get the point away from the segment end point on the specified distance;
* <b>Split</b> - Split the segment to small parts by the segments length;
* <b>LinearInterpolation</b> - Linear interpolation for point on the segment;
* <b>LinearInterpolationByStep</b> - Linear interpolation with specified step;
* <b>IsParallel</b> - Check if two segments are parallel;
* <b>GetRelativeLocationTriangle</b> - Get the segment location relative to the triangle;
* <b>CreateFromLine</b> - Cut the line to the segment by X bounds;
* <b>HasPointProjection</b> - Check if the point has projection to the segment;
* <b>GetPointProjection</b> - Get projection point to the segment;
* <b>Contains</b> - Check if the segment contains the point.

### LineGeo
* <b>DistanceToCircle</b> - Get shortest distance from the line to the circle;
* <b>DistanceToPoint</b> - Get shortest distance to the point;
* <b>HasIntersection</b> - Check if two lines have intersection;
* <b>FindIntersection</b> - Find the intersection point between two lines;
* <b>HasCircleIntersection</b> - Check if the line and the circle has intersection;
* <b>FindCircleIntersection</b> - Find intersection between the line and the circle;
* <b>IsParallel</b> - Check if two lines are parallel;
* <b>Contains</b> - Check if the line contains the point;
* <b>ContainsSegment</b> - Check if the line contains the segment;
* <b>FindSlopeKoef</b> - Get coefficients of line linear function K and B;
* <b>CutByXBounds</b> - Cut the line to the segment by X bounds;
* <b>GetRelativeLocationCircle</b> - Get the line location relative to the circle;
* <b>GetPointProjection</b> - Get projection from the point to the line.

### CurveLineGeo
* <b>Length</b> - Get curve length;
* <b>MinDistanceToPoint</b> - Find the minimal distance from the curve to the point;
* <b>Split</b> - Split the curve line to small parts by the segments length;
* <b>HasIntersection</b> - Check if the curve line and the segment has intersection;
* <b>FindIntersection</b> - Find the intersection point between the segment and the surface.

### CircleGeo
* <b>GetArea</b> - Get the circle area;
* <b>GetEdgePoint</b> - Get the point on the circle edge on the specified angle;
* <b>GetAABB</b> - Get the bounding rect of the circle;
* <b>IsOrthogonal</b> - Check if two circles are orthogonal;
* <b>HasOverlapping</b> - Check if two circles has overlapping;
* <b>GetRelativeLocationLine</b> - Get the line location relative to the circle;
* <b>DistanceToPoint</b> - Get shortest distance from the point to the circle;
* <b>DistanceToSegment</b> - Get shortest distance from the segment to the circle;
* <b>DistanceToLine</b> - Get shortest distance from the line to the circle;
* <b>DistanceToCircle</b> - Get shortest distance from the circle to the circle;
* <b>DistanceToTriangle</b> - Get shortest distance from the circle to the triangle;
* <b>HasLineIntersection</b> - Check if the line and the circle have intersection;
* <b>FindLineIntersection</b> - Find the intersection point between the line and the circle;
* <b>HasRectIntersection</b> - Check if the circle has intersection with the rectangle;
* <b>Contains</b> - Check if the circle/circle sector contains the point.

### EllipseGeo
* <b>GetArea</b> - Get the ellipse area;
* <b>GetEccentricity</b> - Get the ellipse eccentricity;
* <b>GetPerimeter</b> - Get the ellipse perimeter;
* <b>Contains</b> - Check if the axis-parallel ellipse/ellipse sector contains the point.

### TriangleGeo
* <b>Area</b> - Get the triangle area;
* <b>Perimeter</b> - Get the triangle perimeter;
* <b>GetTriangleType</b> - Get the triangle type;
* <b>GetAngles</b> - Get the triangle angles;
* <b>IsRight</b> - Check if one angle is equal 90 degrees;
* <b>IsObtuse</b> - Check if one angle is greater than 90 degrees;
* <b>IsAcute</b> - Check if all angles are less than 90 degrees;
* <b>GetAABB</b> - Get the AABB rect of the triangle;
* <b>Rotate</b> - Rotate the triangle around the point/the center;
* <b>GetCenter</b> - Get average center of the triangle;
* <b>DistanceToPoint</b> - Get shortest distance from the point to the triangle;
* <b>DistanceToCircle</b> - Get shortest distance from the circle to the triangle;
* <b>HasSegmentIntersection</b> - Check if has intersection between the segment and the triangle;
* <b>FindSegmentIntersection</b> - Find the intersection point between the segment and the triangle;
* <b>GetRelativeLocationSegment</b> - Get the segment location relative to the triangle;
* <b>Contains</b> - Check if the triangle contains the point.

### RectGeo
* <b>GetArea</b> - Get area of the rectangle;
* <b>GetCenter</b> - Get the center point of the rectangle;
* <b>GetDimensions</b> - Get width/height of the rectangle;
* <b>GetPoints</b> - Get points of the rectangle based on diagonal 0-2 points;
* <b>GetAABB</b> - Get the AABB rectangle;
* <b>HasCircleIntersection</b> - Check if the circle has intersection with the axis-oriented and given by arbitrary points rectangle;
* <b>HasSegmentIntersection</b> - Check if the segment has intersection with the axis-oriented and given by arbitrary points rectangle;
* <b>FindSegmentIntersection</b> - Find intersection between the segment and the axis-oriented and given by arbitrary points rectangle;
* <b>CreateFromSegment</b> - Get the rectangle with one side equal to segment;
* <b>DistanceToPoint</b> - Get shortest distance from point to the axis-oriented and given by arbitrary points rectangle;
* <b>Contains</b> - Check if the axis-oriented and given by arbitrary points rectangle contains the point.

### SurfaceGeo
* <b>GetArea</b> - Get the surface area;
* <b>GetMinPoint</b> - Get the minimum point of the surface;
* <b>GetMaxPoint</b> - Get the maximum point of the surface;
* <b>GetCenterPoint</b> - Get the surface center point;
* <b>GetAABB</b> - Get the rectangle covering the entire surface;
* <b>DistanceToPoint</b> - Get shortest distance from the surface to the point;
* <b>Contains</b> - Check if the surface contains the point.

### GeoPlanarNet
* <b>Epsilon</b> - tolerance used for comparison operations (default 1e-3);
* <b>AboutEquals</b> - Check if two floating-point numbers are equal;
* <b>AboutZero</b> - Check if floating-point number is equal to zero.
