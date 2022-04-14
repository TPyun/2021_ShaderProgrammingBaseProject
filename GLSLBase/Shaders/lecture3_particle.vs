#version 450

in vec3 a_Position;
in vec3 a_Velocity;
uniform float u_Time;

void main()
{
	gl_Position = vec4(a_Position, 1);
}
