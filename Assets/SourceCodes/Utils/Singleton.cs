using System.Collections.Generic;
using System.Reflection;

///Author by wyb
namespace Utils
{
    
    /// <summary>
    /// 普通单例
    /// </summary>
    /// <typeparam name="T"></typeparam>
	public abstract class Singleton<T>
	{

		private static T _instance;

		public static T Instance
		{
			get
			{
				if(_instance != null)
				{
					return _instance;
				}
                
                System.Type type = typeof(T);
                ///规定T类型的构造函数只有唯一一个，最好是私有构造函数，这样才能体现出单例模式
                ConstructorInfo[] ci = type.GetConstructors(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                //Debug.Log(ci.Length+type.ToString());
                if (ci.Length > 1)
                {
                   // LoggerHandler.LogError("The type that name is : " + type.ToString() +
                        //" is have more than one count!");
                }
                else 
                {

                    _instance = (T)ci[0].Invoke(null);

                }
				return _instance;
			}

		}

		/// <summary>
		///销毁单例 
		/// </summary>
		public static void Release()
		{
			_instance = default(T);
		}

	}



}
