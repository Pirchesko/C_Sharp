using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FastidiousPrincess
{
    /// <summary>
    /// Hall which live Contenders
    /// </summary>
    public class Hall : IHallForPrincess, IHall
    {
        private readonly IContenderGenerator _contenderGenerator;
        
        /// <summary>
        /// hall in which contenders are waiting
        /// </summary>
        private List<Contender> _hall = new List<Contender>();
        
        /// <summary>
        /// sorted hall, for get level of happy Princess
        /// </summary>
        private List<Contender> _hallSort = new List<Contender>();

        private void CreateListHall()
        {
            _hall = _contenderGenerator.CreateListContender();
        }
        
        public Hall(IContenderGenerator contenderGenerator)
        {
            _contenderGenerator = contenderGenerator;
            CreateListHall();
            _hallSort.AddRange(from c in _hall orderby c.Mark select c);
        }

        /// <summary>
        /// Getting conteder from hall
        /// </summary>
        /// <returns>next contender from hall</returns>
        /// <exception cref="Exception"></exception>
        public Contender GetNextContender()
        {
            if (_hall.Count > 0)
            {
                Contender contender = _hall[0];
                _hall.RemoveAt(0);
                return contender;
            }
            else
            {
                throw new Exception("В коридоре больше нету претендентов!");
            }
        }

        /// <summary>
        /// Is contender in hall at the moment?
        /// </summary>
        /// <param name="contender"></param>
        /// <returns>true if contender in hall at the moment</returns>
        public bool CheckContederInHall(IContenderForPrincess contender)
        {
            return _hall.Exists(x => x.Equals(contender));
        }

        /// <summary>
        /// Get mark with search by FristName and LastName
        /// </summary>
        /// <param name="contender"></param>
        /// <returns>mark contender</returns>
        /// <exception cref="Exception"></exception>
        public int GetMarkByName(IContenderForPrincess contender)
        {
            Contender? contenderWithMark = _hallSort.Find(x => x.FirstName == contender.FirstName && x.LastName == contender.LastName);
            if (contenderWithMark != null)
            {
                return contenderWithMark.Mark;
            }
            else
            {
                throw new Exception("Такого претендента не существовало");
            }
        }

        /// <summary>
        /// Get result in mark of happy to Princess
        /// </summary>
        /// <param name="contender"></param>
        /// <returns>happiness</returns>
        public int GetHappyMark(IContenderForPrincess contender)
        {
            var cc = new ContenderComparer();
            //Sort from min to max + 1
            int index = _hallSort.BinarySearch((Contender)contender, cc) + 1;
            if (index <= 50) index = 0;
            return index;
        }
    }
}
