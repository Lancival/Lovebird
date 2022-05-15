using UnityEngine;

public enum Comparison
{
	[InspectorName("=")] Equal,
	[InspectorName("!=")] NotEqual,
	[InspectorName(">")] Greater,
	[InspectorName("<")] Less,
	[InspectorName(">=")] GreaterOrEqual,
	[InspectorName("<=")] LessOrEqual
}