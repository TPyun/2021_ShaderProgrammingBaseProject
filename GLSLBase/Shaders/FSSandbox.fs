#version 450

layout(location=0) out vec4 FragColor;

in vec4 v_Color;

const float PI = 3.141592;

uniform vec3 u_Points[10];
uniform float u_Time;

vec4 CrossPattern()
{
    vec4 returnValue = vec4(1, 1, 1, 1);
    float X = cos(v_Color.x * 20 * PI);
    float Y = cos(v_Color.y * 20 * PI);
    returnValue = vec4(max(X, Y));
    return returnValue;
}


vec4 DrawCircle()
{
    float dis = distance(v_Color.xy, vec2(0.5, 0.5));

    vec4 newColor = vec4(0,0,0,0);

    if( dis < 0.5)
    {
        newColor = vec4(1,1,1,1);
    }
    else
    {
        newColor = vec4(0,0,0,0);
    }

    return newColor;
}


vec4 DrawMultipleCircles()
{
    float dis = distance(v_Color.xy, vec2(0.5, 0.5));
    float temp = cos(dis*40*PI);
    return vec4(temp);
}


vec4 DrawCircleLine()
{
    float dis = distance(v_Color.xy, vec2(0.5, 0.5));

    vec4 newColor = vec4(0,0,0,0);
    if(dis > 0.45 && dis < 0.5)
    {
        newColor = vec4(1);
    }
    else
    {
        newColor = vec4(0);
    }

    return newColor;
}


vec4 DrawCircles()
{
    vec4 returnColor = vec4(0);
    for (int i = 0; i<10; i++)
    {
        float d = distance(u_Points[i].xy, v_Color.xy);
        float temp = sin(10*d*4*PI - 100*u_Time) / u_Time / 20;
        if(d < u_Time)
            returnColor += vec4(temp);
        
        
    }
    return returnColor;
}


vec4 RadarCircle()
{
    float d = distance(vec2(0.5, 0), v_Color.xy);
    float sinValue = sin(d*2*PI- 120* u_Time);
    sinValue = clamp(pow(sinValue, 5), 0, 1);
    vec4 returnColor = vec4(0.5*sinValue);

    for (int i = 0; i < 10; i++)
    {
        float dtemp = distance(u_Points[i].xy, v_Color.xy);
        if (dtemp < 0.1)
        {
            returnColor += vec4(0, 20*sinValue*(0.1-dtemp), 0, 0);
        }
            

    }

    return returnColor;
}


void main()
{
    //FragColor = CrossPattern();
    //FragColor = DrawCircle();
    //FragColor = DrawCircles();
    //FragColor = DrawMultipleCircles();
     FragColor = RadarCircle();
}
