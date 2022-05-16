#version 450

layout(location=0) out vec4 FragColor;

in vec4 v_Color;

const float PI = 3.141592;

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

void main()
{
    //FragColor = CrossPattern();
    //FragColor = DrawCircle();
    //FragColor = DrawCircleLine();
    FragColor = DrawMultipleCircles();
}
