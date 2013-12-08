using System;
using System.Collections;
using System.Linq;
using System.Reflection;

namespace ConferencePlus.Entities.Common
{
	/// <summary>
	/// Maps two different types.
	/// </summary>
	/// <typeparam name="T">Type that is mapped to.</typeparam>
	public static class TypeMapper<T> where T : new()
	{
		/// <summary>
		/// Maps the source to a return type.
		/// </summary>
		/// <param name="source">Soruce type that contains the data that will be mapped to the return type.</param>
		/// <returns>Returns the generic type with the source data.</returns>
		/// <remarks>
		/// TypeMapper performs a recursive deep copy of the source object into the type T object.
		/// The type T must have the same properties as the source type. 
		/// If there are any collecitons they must be of type ICollections (ex. generic version of List) and the collection must be a generic collection.
		/// </remarks>
		public static T Map(object source)
		{
			if (source == null)
			{
				return default(T);
			}

			T destination = Activator.CreateInstance<T>();
			return (T)Map(source, destination);
		}

		private static object Map(object source, object destination)
		{
			Type destinationType = destination.GetType();
			Type sourceType = source.GetType();
			PropertyInfo[] properties = sourceType.GetProperties();

			while (sourceType != null)
			{
				foreach (PropertyInfo property in properties)
				{
					PropertyInfo sourcePropertyInfo = sourceType.GetProperty(property.Name);
					PropertyInfo destinationPropertyInfo = destinationType.GetProperty(property.Name);

					if (destinationPropertyInfo != null && destinationPropertyInfo.GetSetMethod() != null)
					{
						if (sourcePropertyInfo != null)
						{
							object sourcePropertyValue = sourcePropertyInfo.GetValue(source, null);
							object destinationPropertyValue = destinationPropertyInfo.GetValue(destination, null);

							if (sourcePropertyValue != null)
							{
								Type sourcePropertyValueType = sourcePropertyValue.GetType();

								if (sourcePropertyValue is ICollection)
								{
									ICollection sourcePropertyList = sourcePropertyValue as ICollection;
									ICollection destinationPropertyList = destinationPropertyValue as ICollection;

									if (destinationPropertyList != null)
									{
										Type destinationPropertyListType = destinationPropertyList.GetType();

										// Copy only works with generic collections
										if (sourcePropertyList.Count > 0 &&
											destinationPropertyListType.IsGenericType)
										{
											destinationPropertyList = Activator.CreateInstance(destinationPropertyListType) as ICollection;

											foreach (var sourceListValue in sourcePropertyList)
											{
												Type destinationPropertyListValueType = destinationPropertyListType.GetGenericArguments().FirstOrDefault();

												if (destinationPropertyListValueType != null)
												{
													object destinationPropertyListValue = Activator.CreateInstance(destinationPropertyListValueType);
													object mappeddestinationPropertyListValue = Map(sourceListValue, destinationPropertyListValue);
													destinationPropertyListType.GetMethod("Add").Invoke(destinationPropertyList, new[] { mappeddestinationPropertyListValue });
												}
											}

											destinationPropertyInfo.SetValue(destination, destinationPropertyList, null);
										}
									}
								}
								else if (IsNestedCustomType(sourcePropertyValueType))
								{
									object newDestinationValue = Activator.CreateInstance(destinationPropertyInfo.PropertyType);
									object destinationValue = Map(sourcePropertyValue, newDestinationValue);
									destinationPropertyInfo.SetValue(destination, destinationValue, null);
								}
								else
								{
									destinationPropertyInfo.SetValue(destination, sourcePropertyValue, null);
								}
							}
						}
					}
				}

				sourceType = sourceType.BaseType;
			}

			return destination;
		}

		private static bool IsNestedCustomType(Type sourceValueType)
		{
			bool result = false;

			try
			{
				PropertyInfo[] properties = sourceValueType.GetProperties();

				if (sourceValueType.Namespace != null &&
					!sourceValueType.Namespace.StartsWith("System") &&
					properties.Length > 0)
				{
					result = true;
				}
			}
			catch { }

			return result;
		}
	}
}