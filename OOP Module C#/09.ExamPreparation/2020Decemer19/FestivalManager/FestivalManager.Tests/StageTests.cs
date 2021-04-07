// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
    using NUnit.Framework;
    using System;

	public class StageTests
    {
        private Performer perfomer;
        private Song song;
        private Stage stage;


        [SetUp]
        public void Setup()
        {
            this.perfomer = new Performer("Enrique", "Manqka", 25);
            this.song = new Song("Velikanska", new TimeSpan(0, 02, 45));
            this.stage = new Stage();
        }

        //SONG TEST
        [Test]
        public void Ctor()
        {
            Assert.IsNotNull(this.song);

        }
        [Test]
	    public void NameOfSong()
	    {
            var expectedResult = "Velikanska";
            Assert.AreEqual(expectedResult, this.song.Name);
		}

        [Test]
        public void TimeSpanOfSong()
        {
            var expectedResult = new TimeSpan(0,02,45);
            Assert.AreEqual(expectedResult, this.song.Duration);
        }

        [Test]
        public void ToStringMethodTest()
        {
            var expectedResult = $"Velikanska (02:45)";
            Assert.AreEqual(expectedResult, this.song.ToString());
        }

        //PERFOMER TEST
        [Test]
        public void PerfmorerCTOR()
        {
            Assert.IsNotNull(this.perfomer);
        }
        [Test]
        public void NameOfPerfomer()
        {
            Assert.AreEqual("Enrique Manqka", this.perfomer.FullName);
        }
        [Test]
        public void AgeOfPerfmormer()
        {
            Assert.AreEqual(25, this.perfomer.Age);
        }
        [Test]
        public void ListOfSong()
        {
            Assert.IsNotNull(this.perfomer.SongList);
        }

        [Test]
        public void ToStringPerformerMethod()
        {
            Assert.AreEqual("Enrique Manqka", this.perfomer.ToString());
        }

        //STAGE TEST 
        [Test]
        public void StageCtor()
        {
            Assert.IsNotNull(this.stage);
        }
        [Test]
        public void PropertyPerformer()
        {
            Assert.AreEqual(0, this.stage.Performers.Count);
        }
        [Test]
        public void AddMethodWithNull()
        {
            Assert.Throws<ArgumentNullException>(() => this.stage.AddPerformer(null));
        }
        [Test]
        public void AddMethodWitAgeUnder18()
        {
            Assert.Throws<ArgumentException>(() => this.stage.AddPerformer(new Performer("Test","Test",15)));
        }
        [Test]
        public void AddMethod()
        {
            this.stage.AddPerformer(this.perfomer);
            Assert.AreEqual(1, this.stage.Performers.Count);
        }

        [Test]
        public void AddSongWithNull()
        {
            Assert.Throws<ArgumentNullException>(() => this.stage.AddSong(null));
        }
        [Test]
        public void AddSongUnderMinute()
        {
            this.song = new Song("Test", new TimeSpan(0, 0, 45));
            Assert.Throws<ArgumentException>(() => this.stage.AddSong(this.song));
        }
        [Test]
        public void AddSong()
        {
            this.stage.AddSong(this.song);
        }
        [TestCase(null,"Enrique")]
        [TestCase("Velikanska",null)]
        public void AddSongToPerfomerWithNullString(string songName,string performerName)
        {
            Assert.Throws<ArgumentNullException>(() => this.stage.AddSongToPerformer(songName,performerName));
        }
        [TestCase("Ivan","Velikanska")]
        [TestCase("Enrique","Nqma Takava Pesen")]
        public void InvalidSongOrInvalidSong(string songName, string performerName)
        {
            Assert.Throws<ArgumentException>(() => this.stage.AddSongToPerformer(songName, performerName));
        }

        [Test]
        public void AddSongToPerfomer()
        {
            string songName = "Velikanska";
            string perfomer = "Enrique Manqka";
            this.stage.AddPerformer(this.perfomer);
            this.stage.AddSong(this.song);
            var expectedResult = $"Velikanska (02:45) will be performed by Enrique Manqka";
            Assert.AreEqual(expectedResult, this.stage.AddSongToPerformer(songName, perfomer));
        }

        [Test]
        public void PlayMethod()
        {
            this.stage.AddPerformer(this.perfomer);
            this.stage.AddSong(this.song);
            var expectedResult = $"1 performers played 0 songs";
            Assert.AreEqual(expectedResult, this.stage.Play());
        }
    }
}