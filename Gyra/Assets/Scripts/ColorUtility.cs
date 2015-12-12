using UnityEngine;

public static class ColorUtility 
{
	// From: https://github.com/MattRix/UnityDecompiled/blob/cc432a3de42b53920d5d5dae85968ff993f4ec0e/UnityEditor/UnityEditor/EditorGUIUtility.cs
	public static Color HSVToRGB(float H, float S, float V)
	{
		Color white = Color.white;
		if (S == 0f)
		{
			white.r = V;
			white.g = V;
			white.b = V;
		}
		else
		{
			if (V == 0f)
			{
				white.r = 0f;
				white.g = 0f;
				white.b = 0f;
			}
			else
			{
				white.r = 0f;
				white.g = 0f;
				white.b = 0f;
				float num = H * 6f;
				int num2 = (int)Mathf.Floor(num);
				float num3 = num - (float)num2;
				float num4 = V * (1f - S);
				float num5 = V * (1f - S * num3);
				float num6 = V * (1f - S * (1f - num3));
				int num7 = num2;
				switch (num7 + 1)
				{
				case 0:
					white.r = V;
					white.g = num4;
					white.b = num5;
					break;
				case 1:
					white.r = V;
					white.g = num6;
					white.b = num4;
					break;
				case 2:
					white.r = num5;
					white.g = V;
					white.b = num4;
					break;
				case 3:
					white.r = num4;
					white.g = V;
					white.b = num6;
					break;
				case 4:
					white.r = num4;
					white.g = num5;
					white.b = V;
					break;
				case 5:
					white.r = num6;
					white.g = num4;
					white.b = V;
					break;
				case 6:
					white.r = V;
					white.g = num4;
					white.b = num5;
					break;
				case 7:
					white.r = V;
					white.g = num6;
					white.b = num4;
					break;
				}
				white.r = Mathf.Clamp(white.r, 0f, 1f);
				white.g = Mathf.Clamp(white.g, 0f, 1f);
				white.b = Mathf.Clamp(white.b, 0f, 1f);
			}
		}
		return white;
	}
}
