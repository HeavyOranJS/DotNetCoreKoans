using DotNetCoreKoans.Engine;
using Xunit;

namespace DotNetCoreKoans.Koans
{
    public class AboutConstants : Koan
    {
        [Step(1)]
        public void ConstantsMustBeInitalizedAsDeclared()
        {
            const int months = 12;
            Assert.Equal(months, 12);
        }

        [Step(2)]
        public void ConstantsCannotBeChanged()
        {
            //Since C# inserts literal values into compiled
            //code, you will not achieve zen when attempting
            //to change them after definition.
            const int days = 365;
            // days = days + 1; //does not even compile -- gives CS0131
            // also this means compile errors and runtime exceptions are different things
            Assert.Equal(365, days);
        }

        [Step(3)]
        public void ConstantsOfTheSameTypeCanBeDeclaredAtTheSameTime()
        {
            //You can achieve zen (and save keystrokes) by defining
            //constants of the same type as one.
            const int months = 12, weeks = 52, days = 365;
            Assert.Equal(typeof(int), months.GetType());
            Assert.Equal(typeof(int), weeks.GetType());
            Assert.Equal(typeof(int), days.GetType());
        }

        [Step(4)]
        public void ConstantsCanBeUsedInExpressionsToInitializeOtherConstants()
        {
            const int months = 12;
            const int weeks = 52;
            const int days = 365;

            const double daysPerWeek = (double)days / (double)weeks;
            const double daysPerMonth = (double)days / (double)months;
            Assert.Equal(7.019230769230769d, daysPerWeek);
            Assert.Equal(30.416666666666668d, daysPerMonth);

            //Constants can be used in arithmetic to set other constant values.
            //They can also initialize each other.
        }

        public class Animal
        {
            public const int Legs = 4;

            public int LegsInAnimal() { return Legs; }

            public class NestedAnimal
            {
                public int LegsInNestedAnimal() { return Legs; }
            }
        }

        [Step(5)]
        public void NestedClassesInheritConstantsFromEnclosingClasses()
        {
            var nestedAnimal = new Animal.NestedAnimal();
            Assert.Equal(Animal.Legs, nestedAnimal.LegsInNestedAnimal());

            //QUESTION: Do nested classes inherit their parent's scope?

            var animal = new Animal();
            // you cannot get to public consts from class insatnce
            // there needs to be a getter -- LegsInAnimal in this case
            Assert.Equal(Animal.Legs, animal.LegsInAnimal());
            Assert.Equal(nestedAnimal.LegsInNestedAnimal(), animal.LegsInAnimal());
            // but this does not work: NestedAnimal does not have access
            // public const of inclusive class -- it's out of scope
            // Assert.Equal(Animal.NestedAnimal.Legs, animal.LegsInAnimal());
        }

        public class Reptile : Animal
        {
            public int LegsInReptile()
            {
                return Legs;
            }
        }

        [Step(6)]
        public void SubclassesInheritConstantsFromParentClasses()
        {
            //If a Reptile is an Animal, zen is achieved
            //when you realize they too will have legs.
            var reptile = new Reptile();
            Assert.Equal(Animal.Legs, reptile.LegsInReptile());
            // okay, okay, but what about Reptile.Legs -- works, great
            Assert.Equal(Reptile.Legs, reptile.LegsInReptile());
        }

        public class MyAnimals
        {
            public const int Legs = 2;

            public class Bird : Animal
            {
                public int LegsInBird()
                {
                    return Legs;
                }
            }
        }

        [Step(7)]
        public void WhoWinsWithBothNestedAndInheritedConstants()
        {
            var bird = new MyAnimals.Bird();
            Assert.Equal(Animal.Legs, bird.LegsInBird());

            // i mean this koan is great, but not about constans :D

            /* QUESTION: Which has precedence: The constant in the lexical scope,
               or the constant from the inheritance hierarchy? */
        }
    }
}
