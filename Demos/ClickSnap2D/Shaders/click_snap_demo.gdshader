shader_type canvas_item;

uniform bool is_selected = false;

void vertex() {
	// Called for every vertex the material is visible on.
}

void fragment() {
	// Called for every pixel the material is visible on.
	if(is_selected)
	{
		vec4 texColor = texture(TEXTURE, UV);
		COLOR = vec4(
			1.0, 
			0.0, 
			0.0, 
			texColor.a);
	}
}
//void light() {
//	// Called for every pixel for every light affecting the CanvasItem.
//	// Uncomment to replace the default light processing function with this one.
//}
