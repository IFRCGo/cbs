using System;
using Machine.Specifications;

namespace Domain.Specs.for_Feature
{
    public class when_creating_with_unwanted_separators
    {
        const string path = "Some.place";
        static Exception result;

        Because of = () => result = Catch.Exception(() => new Feature(path));

        It should_throw_wrong_feature_path_format = () => result.ShouldBeOfExactType<InvalidFeaturePathFormat>();
    }
}