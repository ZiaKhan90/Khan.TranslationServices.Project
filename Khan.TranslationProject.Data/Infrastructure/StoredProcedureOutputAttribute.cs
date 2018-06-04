using System;

namespace Khan.TranslationProject.Data.Infrastructure
{
    /// <summary>
    /// Marks a property as stored procedure output parameter
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    sealed class StoredProcedureOutputAttribute : Attribute{}
}