using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SitecoreCognitiveServices.Foundation.MSSDK.Enums;
using SitecoreCognitiveServices.Foundation.MSSDK.Http;
using SitecoreCognitiveServices.Foundation.MSSDK.Vision.Models.Face;
using SitecoreCognitiveServices.Foundation.MSSDK.Vision;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Tests.Repositories.Vision
{
    [TestFixture]
    public class FaceRepositoryTests : BaseTestFixture
    {
        protected FaceRepository _sut;
        protected IMicrosoftCognitiveServicesApiKeys _keys;

        protected string _maleImageUrl = "https://sportshub.cbsistatic.com/i/r/2017/10/17/5349d0ff-26de-4d15-a403-4c11a5b0611b/thumbnail/770x433/f8a927ba6b8217c7a584e8153b2339b8/lebronjames-101717.jpg";

        protected string _labron1 = "https://sportshub.cbsistatic.com/i/r/2017/11/24/c8268a78-94ff-46ac-8ee1-d810068f0721/thumbnail/770x433/ef4d306a3254a57b05a238de903f11eb/lebronjames-112417.jpg";
        protected string _labron2 = "https://i1.wp.com/www.nationalreview.com/wp-content/uploads/2018/05/RTX66A5E.jpg";
        protected string _labron3 = "https://s2.eestatic.com/2018/02/01/deportes/baloncesto/nba/LeBron_James-Golden_State_Warriors-Cleveland_Cavaliers-Los_Angeles_Lakers-NBA-Baloncesto-NBA_281734141_63206313_1024x576.jpg";
        protected string _labron4 = "https://sportshub.cbsistatic.com/i/r/2017/10/17/5349d0ff-26de-4d15-a403-4c11a5b0611b/thumbnail/770x433/f8a927ba6b8217c7a584e8153b2339b8/lebronjames-101717.jpg";
        protected string _labron5 = "http://www.gigantes.com/wp-content/uploads/2017/10/Cleveland-e1507671330184.jpg";

        protected string _theRock1 = "http://img.wennermedia.com/social/dwayne-the-rock-johnson-for-president-094088ba-7415-4b23-8a9a-0150b55749ec.jpg";
        protected string _theRock2 = "http://tryplasticsurgery.com/media/k2/items/cache/233826a67be66a810b23a263230da62e_XL.jpg";
        protected string _theRock3 = "http://www.dv.is/wp-content/uploads/2018/04/dwayne-the-rock-johnson-birthday-gi.jpg";
        protected string _theRock4 = "https://www.infobae.com/new-resizer/yf1dXn4Uagrp9ys8JAE7wszMEDY=/600x0/filters:quality(100)/s3.amazonaws.com/arc-wordpress-client-uploads/infobae-wp/wp-content/uploads/2018/04/26174311/Dwayne-johnson-The-Rock-1.jpg";
        protected string _theRock5 = "http://beta.ems.ladbiblegroup.com/s3/content/808x455/d79fb7905a24f8c0111e4382899454eb.png";

        protected string _faraday = "https://i1.wp.com/geeknewsnetwork.net/wp-content/uploads/2015/09/FARADAY-cropped-rev-b-1024x714.jpg";

        protected string _personGroupId = "test-person-group-id";
        protected string _personGroupName = "Test Person Group Name";
        protected string _personGroupUserData = "Test Person Group User Data";
        protected string _personUserData = "Test Person User Data";
        protected string _labronName = "Labron James";
        protected string _theRockName = "The Rock";

        protected string _faceListId = "face-list-id";
        protected string _faceListName = "Face List Name";
        protected string _faceListUserData = "Face List User Data";

        protected Person[] GetPersonList() {
            return new []
            {
                new Person
                {
                    Name = _theRockName,
                    PersonId = new Guid("15a220a2-ed0a-4f2f-996e-fe4a011ffe5b"),
                    PersistedFaceIds = new []
                    {
                        new Guid("2b1ce9fa-bca7-4c7e-815d-b1935c0780dd"),
                        new Guid("36b694f6-6b85-47cb-8bf8-1d7a41b1ea69"),
                        new Guid("534feafb-e28e-463b-9125-3d2ce444116f"),
                        new Guid("ab75aee0-7d9f-4fd6-8cc8-ceee45732f47"),
                        new Guid("c822583e-2ae1-4295-9229-21f9db603b10")
                    }
                },
                new Person
                {
                    Name = _labronName,
                    PersonId = new Guid("1c782ebf-4c0f-421f-9ab2-dfc948ef5bfc"),
                    PersistedFaceIds = new Guid[]
                    {
                        new Guid("4dbe129e-9569-49f7-ad82-58343186ee54"),
                        new Guid("7a50c859-6b10-43ff-a8db-0ae55620f01a"),
                        new Guid("93bf373c-f369-4be2-a3dc-ed5fd64d603d"),
                        new Guid("9d95dc42-a87b-44a7-9479-43cebf0e2eae"),
                        new Guid("f2128570-52c9-4b00-9c91-9d6ca325d9d6")
                    }
                }
            };
        }

        protected IEnumerable<FaceAttributeType> _faceAttributes = new List<FaceAttributeType>
        {
            FaceAttributeType.Age,
            FaceAttributeType.FacialHair,
            FaceAttributeType.Gender,
            FaceAttributeType.Glasses,
            FaceAttributeType.HeadPose,
            FaceAttributeType.Smile,
            FaceAttributeType.Emotion
        };

        [SetUp]
        public void Setup()
        {
            _keys = GetKeys();
            var client = new MicrosoftCognitiveServicesRepositoryClient();

            _sut = new FaceRepository(_keys, client);
        }
        
        #region Face

        #region Detect

        [Test]
        public void Detect()
        {
            //arrange
            
            //act
            var result = _sut.Detect(_maleImageUrl, false, true, _faceAttributes);

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Length);
            Assert.IsNotNull(result[0].FaceAttributes);
            Assert.IsNotNull(result[0].FaceRectangle);
            Assert.AreEqual("male", result[0].FaceAttributes.Gender);
        }

        #endregion

        #region Find Similar

        //[Test]
        //public void FindSimilar()
        //{
        //    //arrange

        //    //act
        //    var result = _sut.FindSimilar(Guid faceId, Guid[] faceIds, int maxNumOfCandidatesReturned = 20);
        //    //var result = _sut.FindSimilar(Guid faceId, string faceListId, int maxNumOfCandidatesReturned = 20);
        //    //var result = _sut.FindSimilar(Guid faceId, string faceListId, FindSimilarMatchMode mode, int maxNumOfCandidatesReturned = 20);
        //    //var result = _sut.FindSimilar(Guid faceId, Guid[] faceIds, FindSimilarMatchMode mode, int maxNumOfCandidatesReturned = 20);

        //    //assert
        //    Assert.IsNotNull(result);
        //    Assert.AreEqual("male", result[0].FaceAttributes.Gender);
        //}

        #endregion

        #region Group

        //[Test]
        //public void Group()
        //{
        //    //arrange

        //    //act
        //    var result = _sut.Group(Guid[] faceIds);

        //    //assert
        //    Assert.IsNotNull(result);
        //    Assert.AreEqual("male", result[0].FaceAttributes.Gender);
        //}

        #endregion

        #region Identify

        [Test]
        public void Identify()
        {
            //arrange
            var list = GetPersonList();

            //act
            var result = _sut.Identify(_personGroupId, new [] { list.First().PersistedFaceIds.First() });
            
            //assert
            Assert.IsNotNull(result[0].Candidates[0].PersonId);
        }

        #endregion

        #region Verify

        //[Test]
        //public void Verify()
        //{
        //    //arrange

        //    //act
        //    var result = _sut.Verify(Guid faceId1, Guid faceId2);
        //    //var result = _sut.Verify(Guid faceId, string personGroupId, Guid personId);

        //    //assert
        //    Assert.IsNotNull(result);
        //    Assert.AreEqual("male", result[0].FaceAttributes.Gender);
        //}

        #endregion

        #endregion

        #region Face List

        #region Create Face List

        [Test]
        public void CreateFaceList()
        {
            //arrange

            //act
            _sut.CreateFaceList(_faceListId, _faceListName, _faceListUserData);

            //assert
        }

        #endregion

        #region Add Face To Face List

        [Test]
        public void AddFaceToFaceList()
        {
            //arrange

            //act
            var result = _sut.AddFaceToFaceList(_faceListId, _faraday, _faceListUserData);
            
            //assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.PersistedFaceId);
        }

        #endregion

        #region Get Face List

        [Test]
        public void GetFaceList()
        {
            //arrange

            //act
            var result = _sut.GetFaceList(_faceListId);

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.PersistedFaces.Length);
        }

        #endregion

        #region List Face Lists

        [Test]
        public void ListFaceLists()
        {
            //arrange

            //act
            var result = _sut.ListFaceLists();

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Length);
        }

        #endregion

        #region Update Face List

        [Test]
        public void UpdateFaceList()
        {
            //arrange

            //act
            _sut.UpdateFaceList(_faceListId, _faceListName, _faceListUserData);

            //assert
        }

        #endregion

        #region Delete Face From Face List

        [Test]
        public void DeleteFaceFromFaceList()
        {
            //arrange
            var list = _sut.GetFaceList(_faceListId);

            //act
            _sut.DeleteFaceFromFaceList(_faceListId, list.PersistedFaces[0].PersistedFaceId);

            //assert
        }

        #endregion

        #region Delete Face List

        [Test]
        public void DeleteFaceList()
        {
            //arrange

            //act
            _sut.DeleteFaceList(_faceListId);

            //assert
        }

        #endregion

        #endregion

        #region Large Face List



        #endregion

        #region Large Person Group



        #endregion

        #region Large Person Group Person



        #endregion

        #region Person Group

        #region Create Person Group

        [Test]
        public void CreatePersonGroup()
        {
            //arrange

            //act
            _sut.CreatePersonGroup(_personGroupId, _personGroupName);

            //assert
        }

        #endregion

        #region Get Person Group

        [Test]
        public void GetPersonGroup()
        {
            //arrange

            //act
            var result = _sut.GetPersonGroup(_personGroupId);

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(_personGroupName, result.Name);
        }

        #endregion

        #region List Person Groups

        [Test]
        public void ListPersonGroups()
        {
            //arrange

            //act
            var result = _sut.ListPersonGroups();

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Length);
            Assert.AreEqual(_personGroupName, result[0].Name);
        }

        #endregion

        #region Update Person Group

        [Test]
        public void UpdatePersonGroup()
        {
            //arrange

            //act
            _sut.UpdatePersonGroup(_personGroupId, _personGroupName, _personGroupUserData);
            var result = _sut.GetPersonGroup(_personGroupId);

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(_personGroupUserData, result.UserData);
        }

        #endregion

        #region Train Person Group

        [Test]
        public void TrainPersonGroup()
        {
            //arrange

            //act
            _sut.TrainPersonGroup(_personGroupId);

            //assert
        }

        #endregion

        #region Get Person Group Training Status

        [Test]
        public void GetPersonGroupTrainingStatus()
        {
            //arrange

            //act
            var result = _sut.GetPersonGroupTrainingStatus(_personGroupId);

            //assert
            Assert.IsNotNull(result);
            Assert.AreNotEqual(Status.NotStarted, result.Status);
            Assert.AreNotEqual(Status.Failed, result.Status);
        }

        #endregion

        #region Delete Person Group

        [Test]
        public void DeletePersonGroup()
        {
            //arrange

            //act
            _sut.DeletePersonGroup(_personGroupId);

            //assert
        }

        #endregion

        #endregion

        #region Person Group Person

        #region Add Person Face

        [Test]
        public void AddPersonFace()
        {
            //arrange
            var list = GetPersonList();

            //act
            var result1 = _sut.AddPersonFace(_personGroupId, list[0].PersonId, _theRock1);
            var result2 = _sut.AddPersonFace(_personGroupId, list[0].PersonId, _theRock2);
            var result3 = _sut.AddPersonFace(_personGroupId, list[0].PersonId, _theRock3);
            var result4 = _sut.AddPersonFace(_personGroupId, list[0].PersonId, _theRock4);
            var result5 = _sut.AddPersonFace(_personGroupId, list[0].PersonId, _theRock5);

            var result6 = _sut.AddPersonFace(_personGroupId, list[1].PersonId, _labron1);
            var result7 = _sut.AddPersonFace(_personGroupId, list[1].PersonId, _labron2);
            var result8 = _sut.AddPersonFace(_personGroupId, list[1].PersonId, _labron3);
            var result9 = _sut.AddPersonFace(_personGroupId, list[1].PersonId, _labron4);
            var result10 = _sut.AddPersonFace(_personGroupId, list[1].PersonId, _labron5);

            //assert
            Assert.IsNotNull(result1);
            Assert.IsNotNull(result2);
            Assert.IsNotNull(result3);
            Assert.IsNotNull(result4);
            Assert.IsNotNull(result5);
            Assert.IsNotNull(result6);
            Assert.IsNotNull(result7);
            Assert.IsNotNull(result8);
            Assert.IsNotNull(result9);
            Assert.IsNotNull(result10);
        }

        #endregion

        #region Create Person

        [Test]
        public void CreatePerson()
        {
            //arrange

            //act
            var result1 = _sut.CreatePerson(_personGroupId, _labronName);
            var result2 = _sut.CreatePerson(_personGroupId, _theRockName);

            //assert
            Assert.IsNotNull(result1);
            Assert.IsNotNull(result2);
            Assert.AreEqual("male", result1.PersonId);
        }

        #endregion

        #region Delete Person

        [Test]
        public void DeletePerson()
        {
            //arrange
            var list = GetPersonList();

            //act
            foreach (var person in list)
            {
                _sut.DeletePerson(_personGroupId, person.PersonId);
            }
            
            //assert
        }

        #endregion

        #region Delete Person Face

        [Test]
        public void DeletePersonFace()
        {
            //arrange
            var list = GetPersonList();

            //act
            _sut.DeletePersonFace(_personGroupId, list.First().PersonId, list.First().PersistedFaceIds.First());

            //assert
        }

        #endregion

        #region Get Person

        [Test]
        public void GetPerson()
        {
            //arrange
            var list = GetPersonList();

            //act
            var result = _sut.GetPerson(_personGroupId, list.First().PersonId);

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(_theRockName, result.Name);
        }

        #endregion

        #region Get Person Face

        [Test]
        public void GetPersonFace()
        {
            //arrange
            var list = GetPersonList();

            //act
            var result = _sut.GetPersonFace(_personGroupId, list.First().PersonId, list.First().PersistedFaceIds.First());

            //assert
            Assert.IsNotNull(result);
        }

        #endregion

        #region Get Persons

        [Test]
        public void GetPersons()
        {
            //arrange

            //act
            var result = _sut.GetPersons(_personGroupId);
            
            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Length);
        }

        #endregion

        #region Update Person

        [Test]
        public void UpdatePerson()
        {
            //arrange
            var list = GetPersonList();

            //act
            _sut.UpdatePerson(_personGroupId, list.First().PersonId, list.First().Name, _personUserData);

            //assert
        }

        #endregion

        #region Update Person Face

        [Test]
        public void UpdatePersonFace()
        {
            //arrange
            var list = GetPersonList();

            //act
            _sut.UpdatePersonFace(_personGroupId, list[0].PersonId, list[0].PersistedFaceIds[0], _personUserData);

            //assert
        }

        #endregion

        #endregion
    }
}
