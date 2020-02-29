using System;
using RoR2;
using UnityEditor;
using UnityEngine;
using BepInEx;
using R2API;
using UnityEngine.SceneManagement;
using UnityEngine.Scripting;

namespace AreaRelit
{
	[BepInPlugin("com.ohway.areacolor", "Area Recolor", "1.0")]
	public class AreaRelit : BaseUnityPlugin
	{
		public bool enablePanel = false;

		private int clickedR = 0;
		private int clickedG = 0;
		private int clickedB = 0;

		public void Awake()
		{
			SceneManager.activeSceneChanged += ResetCount;
			//SceneManager.sceneLoaded += Retint;
		}

		private void ResetCount(Scene arg0, Scene arg1)
		{
			clickedR = clickedG = clickedB = 0;
		}

		public void Retint(Scene scene, LoadSceneMode mode)
		{
			//switch (scene.name)
			//{
			//	case "blackbeach2":
			//	case "blackbeach":
			//		break;
			//	case "title":
			//		Light[] lights = FindObjectsOfType<Light>() as Light[];
			//		foreach (Light light in lights)
			//		{
			//			Color c = new Color(100.0f / 255.0f, 100.0f / 255.0f, 0);
			//			light.color -= c;
			//			clickedR = 10;
			//			clickedB = 10;
			//		}
			//		break;
			//	case "":
			//		break;
			//}
		}

		public void Update()
		{
			float dt = Time.deltaTime;

			if (Input.GetKeyDown(KeyCode.F6))
			{
				enablePanel = !enablePanel;
			}
		}

		public void OnDestroy()
		{
			//SceneManager.sceneLoaded -= Retint;
		}

		public void OnGUI()
		{
			if (enablePanel)
			{
				if (GUILayout.Button("Reset Lighting"))
				{
					Light[] lights = FindObjectsOfType<Light>() as Light[];
					foreach (Light light in lights)
					{
						Color c = new Color(10.0f * clickedR / 255.0f, 10.0f * clickedG / 255.0f, 10.0f * clickedB / 255.0f);
						light.color -= c;
					}
					clickedR = clickedG = clickedB = 0;
				}

				if (GUILayout.Button(SceneManager.GetActiveScene().name))
				{ }

				GUILayout.BeginHorizontal();
				GUILayout.Label(Convert.ToString(clickedR));
				GUILayout.Label(Convert.ToString(clickedG));
				GUILayout.Label(Convert.ToString(clickedB));
				GUILayout.EndHorizontal();

				GUILayout.BeginHorizontal();
				if (GUILayout.Button("+(10/255, 0, 0) to all lights"))
				{
					Light[] lights = FindObjectsOfType<Light>() as Light[];
					foreach (Light light in lights)
					{
						light.color += new Color(10.0f / 255.0f, 0, 0);
					}
					clickedR++;
				}

				if (GUILayout.Button("+(0, 10/255, 0) to all lights"))
				{
					Light[] lights = FindObjectsOfType<Light>() as Light[];
					foreach (Light light in lights)
					{
						light.color += new Color(0, 10.0f / 255.0f, 0);
					}
					clickedG++;
				}

				if (GUILayout.Button("+(0, 0, 10/255) to all lights"))
				{
					Light[] lights = FindObjectsOfType<Light>() as Light[];
					foreach (Light light in lights)
					{
						light.color += new Color(0, 0, 10.0f / 255.0f);
					}
					clickedB++;
				}
				GUILayout.EndHorizontal();
				GUILayout.BeginHorizontal();
				if (GUILayout.Button("-(10/255, 0, 0) to all lights"))
				{
					Light[] lights = FindObjectsOfType<Light>() as Light[];
					foreach (Light light in lights)
					{
						light.color -= new Color(10.0f / 255.0f, 0, 0);
					}
					clickedR--;
				}

				if (GUILayout.Button("-(0, 10/255, 0) to all lights"))
				{
					Light[] lights = FindObjectsOfType<Light>() as Light[];
					foreach (Light light in lights)
					{
						light.color -= new Color(0, 10.0f / 255.0f, 0);
					}
					clickedG--;
				}

				if (GUILayout.Button("-(0, 0, 10/255) to all lights"))
				{
					Light[] lights = FindObjectsOfType<Light>() as Light[];
					foreach (Light light in lights)
					{
						light.color -= new Color(0, 0, 10.0f / 255.0f);
					}
					clickedB--;
				}
				GUILayout.EndHorizontal();
				if (GUILayout.Button("+ (10 / 255) in RGB to all lights"))
				{
					Light[] lights = FindObjectsOfType<Light>() as Light[];
					foreach (Light light in lights)
					{
						light.color += new Color(10.0f / 255.0f, 10.0f / 255.0f, 10.0f / 255.0f);
					}
					clickedR++;
					clickedG++;
					clickedB++;
				}
				if (GUILayout.Button("- (10 / 255) in RGB to all lights"))
				{
					Light[] lights = FindObjectsOfType<Light>() as Light[];
					foreach (Light light in lights)
					{
						light.color -= new Color(10.0f / 255.0f, 10.0f / 255.0f, 10.0f / 255.0f);
					}
					clickedR--;
					clickedG--;
					clickedB--;
				}
			}
		}
	}
}
