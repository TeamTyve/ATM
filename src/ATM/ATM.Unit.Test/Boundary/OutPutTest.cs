using System.Collections.ObjectModel;
using ATM.Classes;
using ATM.Classes.Interfaces;
using NSubstitute;
using NUnit.Framework;

namespace ATM.Unit.Test.Boundary
{
    [TestFixture]
    public class OutPutTest
    {
        [Test]
        public void Output_Format_Text()
        {
            var uut = new Output
            {
            };

            uut.Print(new ObservableCollection<ITrack>
            {
                new Track("Tag;0;0;0;00010101010101001")
            });
        }
    }
}