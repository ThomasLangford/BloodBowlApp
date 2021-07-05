using Microsoft.Extensions.Localization;
using Moq;

namespace BloodBowlAPITests.Mocks
{
    public static class TestContants
    {
        public static readonly string TPREFIX = "$T$_";
    }

    public class LocalizerMock<T> : Mock<IStringLocalizer<T>>
    {
        public LocalizerMock()
        {
            this.Setup(loc => loc[It.IsAny<string>()]).Returns((string s) => GetFakeSkill(s));
        }

        private static LocalizedString GetFakeSkill(string name)
        {
            if (name == null)
            {
                name = "";
            }

            return new LocalizedString(name, $"{TestContants.TPREFIX}{name}");
        }
        //public LocalizedString this[string name] => throw new NotImplementedException();

        //public LocalizedString this[string name, params object[] arguments] => throw new NotImplementedException();

        //public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
