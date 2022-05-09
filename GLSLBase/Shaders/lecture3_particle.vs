#version 450

in vec3 a_Position;
in vec3 a_Velocity;

uniform float u_Time;
uniform vec3 u_Accel;

void main()
{
	float t = u_Time;
	float tt = u_Time * u_Time;
	vec3 newPos;
	newPos = a_Position + a_Velocity  * t + 0.5 * u_Accel * tt;
	gl_Position = vec4(newPos, 1);
}

	//a_Velocity초기속도