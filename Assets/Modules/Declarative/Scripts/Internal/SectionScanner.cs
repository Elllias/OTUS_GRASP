using System;
using System.Collections.Generic;
using System.Reflection;

namespace Declarative
{
    public sealed class SectionScanner
    {
        private static readonly Type SECTION_ATTRIBUTE_TYPE = typeof(SectionAttribute);

        internal static Dictionary<Type, object> ScanSections(DeclarativeModel target)
        {
            var sections = new Dictionary<Type, object> {{target.GetType(), target}};
            ScanSectionsRecurcively(target, sections);
            return sections;
        }

        private static void ScanSectionsRecurcively(object target, Dictionary<Type, object> sections)
        {
            var targetType = target.GetType();
            var fields = ReflectionUtils.RetrieveFields(targetType);

            for (int i = 0, count = fields.Count; i < count; i++)
            {
                var field = fields[i];
                if (!field.IsDefined(SECTION_ATTRIBUTE_TYPE))
                {
                    continue;
                }

                var type = field.FieldType;
                var section = field.GetValue(target);

                sections.Add(type, section);
                ScanSectionsRecurcively(section, sections);
            }
        }
    }
}