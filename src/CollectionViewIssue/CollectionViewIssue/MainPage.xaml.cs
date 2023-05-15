using Sharpnado.CollectionView.Paging;
using Sharpnado.CollectionView.Services;
using Sharpnado.CollectionView.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CollectionViewIssue
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        private Dictionary<int, SillyDude>  _Data =  new  Dictionary<int, SillyDude>();
        private const int PageSize = 20;
        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
            Title = "Reload";
            LoadFakeData();
            var list = new List<SillyDudeVmo>();
            var item = new SillyDude(1, "hola", "hola", "hola", "hola", 1, "hola", "hola");
            list.Add(new SillyDudeVmo(item));
            SillyPeople = new ObservableCollection<SillyDudeVmo>((List<SillyDudeVmo>)list);
            SillyPeoplePaginator = new Paginator<SillyDude>(LoadSillyPeoplePageAsync, pageSize: PageSize);
            //SillyPeoplePaginator.LoadPage(1, false);
            
        }
        public void LoadFakeData()
        {
               int _peopleCounter = 0;
        _Data = new Dictionary<int, SillyDude>
            {
                {
                    ++_peopleCounter, new SillyDude(
                        _peopleCounter,
                        "Will Ferrell",
                        "Actor",
                        "Hey.\nThey laughed at Louis Armstrong when he said he was gonna go to the moon.\nNow he’s up there, laughing at them.",
#if LOCAL_DATA
                            "will_ferrell.jpg",
#else
                        "https://news.usc.edu/files/2017/03/Will-Ferrell-Step-Brothers_Horizontal_web-824x549.jpg",
#endif
                        4,
                        "Ferrell",
                        "https://sayingimages.com/wp-content/uploads/dear-monday-will-ferrell-memes.jpg",
                        "https://youtu.be/sPFRZP4qY7I?t=26")
                },
                {
                    ++_peopleCounter, new SillyDude(
                        _peopleCounter,
                        "Knights of Ni",
                        "Knights",
                        "Keepers of the sacred words 'Ni', 'Peng', and 'Neee-Wom'",
#if LOCAL_DATA
                            "knights_of_ni.jpg",
#else
                        "https://upload.wikimedia.org/wikipedia/en/e/eb/Knightni.jpg",
#endif
                        5,
                        "ni!",
                        "https://i.imgflip.com/1fyfpo.jpg",
                        "https://www.youtube.com/watch?v=zIV4poUZAQo")
                },
                {
                    ++_peopleCounter, new SillyDude(
                        _peopleCounter,
                        "Jean-Claude",
                        "Actor",
                        "J’adore les cacahuètes.\nTu bois une bière et tu en as marre du goût. Alors tu manges des cacahuètes.\nLes cacahuètes, c’est doux et salé, fort et tendre, comme une femme. Manger des cacahuètes. It’s a really strong feeling.\nEt après tu as de nouveau envie de boire une bière.\nLes cacahuètes, c’est le mouvement perpétuel à la portée de l’homme.",
#if LOCAL_DATA
                            "jean_claude_van_damme.jpg",
#else
                        "https://m.media-amazon.com/images/M/MV5BNjU1NzVkOWMtYmJjYy00M2UwLTkxYmEtNmU0YjI5M2ZhYTU3XkEyXkFqcGdeQXVyMjUyNDk2ODc@._V1_.jpg",
#endif
                        5,
                        "VanDamme",
                        "https://www.planet.fr/files/styles/pano_xxl/public/images/diaporama/5/8/0/1615085/vignette-focus_3.jpg?itok=zMC9zW1c")
                },
                {
                    ++_peopleCounter, new SillyDude(
                        _peopleCounter,
                        "Triumph",
                        "Insult Comic Dog",
                        "Occupy Wall Street, talking to a trader with a Fox News mustache on.\nThese protesters with their whining and crying right?\nDon't they realize that their public education are being funded from the taxes you evade each year?\nI don't want to keep you, you're a good man! You better hurry back from lunch so you can collect your hurry back from lunch bonus.",
#if LOCAL_DATA
                            "louis_ck.jpg",
#else
                        "https://tonyhellerakastevengoddardisnotasociopath.files.wordpress.com/2014/09/triumph-the-insult-comic-dog.jpg",
#endif
                        2,
                        "Triumph",
                        "https://i.imgflip.com/xi0tk.jpg",
                        "https://youtu.be/O-253uBJap8?t=315")
                },
                {
                    ++_peopleCounter, new SillyDude(
                        _peopleCounter,
                        "Ricky Gervais",
                        "Comedian",
                        "Science seeks the truth. And it does not discriminate. For better or worse it finds things out.\nScience is humble.\nIt knows what it knows and it knows what it doesn’t know. It bases its conclusions and beliefs on hard evidence -­- evidence that is constantly updated and upgraded.\nIt doesn’t get offended when new facts come along. It embraces the body of knowledge.\nIt doesn’t hold on to medieval practices because they are tradition.",
#if LOCAL_DATA
                            "louis_ck.jpg",
#else
                        "https://resize-parismatch.lanmedia.fr/rcrop/250,250/img/var/news/storage/images/paris-match/people-a-z/ricky-gervais/6126908-7-fre-FR/Ricky-Gervais.jpg",
#endif
                        3,
                        "Gervais",
                        "https://pics.me.me/what-can-be-more-arrogant-than-believing-that-the-same-13060011.png")
                },
                {
                    ++_peopleCounter, new SillyDude(
                        _peopleCounter,
                        "Steve Carell",
                        "Comedian",
                        "Vincent van Gogh. Everyone told him: \"You only have one ear. You cannot be a great artist.\"\nAnd you know what he said?\n\"I can\'t hear you.",
#if LOCAL_DATA
                            "louis_ck.jpg",
#else
                        "https://pixel.nymag.com/imgs/daily/vulture/2018/12/22/23-brick.w330.h330.jpg",
#endif
                        3,
                        "Carell",
                        "https://sayingimages.com/wp-content/uploads/fool-me-once-michael-scott-memes-1.jpg",
                        "https://youtu.be/N9Z4vqysxMQ?t=92")
                },
                {
                    ++_peopleCounter, new SillyDude(
                        _peopleCounter,
                        "Father Ted",
                        "Priest",
                        "My Lovely Horse,\r\nRunning through the field,\r\nWhere are you going,\r\nWith your fetlocks blowing,\r\nIn the wind.\r\n\r\n“I want to shower you with sugar lumps,\r\nAnd ride you over fences,\r\nI want to polish your hooves every single day,\r\nAnd bring you to the horse dentist.\r\n\r\n“My lovely horse,\r\nYou’re a pony no more,\r\nRunning around,\r\nWith a man on your back,\r\nLike a train in the night,\r\nLike a train in the night!”",
#if LOCAL_DATA
                            "louis_ck.jpg",
#else
                        "https://vignette.wikia.nocookie.net/fatherted/images/b/b2/Ted.jpg",
#endif
                        4,
                        "Ted",
                        "https://cdn.psychologytoday.com/sites/default/files/styles/image-article_inline_full/public/blogs/129003/2014/08/158581-164751.jpg?itok=f7HhI_lo",
                        "https://www.youtube.com/watch?v=jzYzVMcgWhg")
                },
                {
                    ++_peopleCounter, new SillyDude(
                        _peopleCounter,
                        "Moss",
                        "IT Guy",
                        "Did you see that ludicrous display last night?\nThe thing about Arsenal is, they always try to walk it in!",
#if LOCAL_DATA
                            "louis_ck.jpg",
#else
                        "https://i.ytimg.com/vi/DJMr-mLjL1s/hqdefault.jpg",
#endif
                        3,
                        "Moss",
                        "https://images1.memedroid.com/images/UPLOADED8/501f9cd68575e.jpeg",
                        "https://youtu.be/NKHyqjHqQLU?t=32")
                },
                {
                    ++_peopleCounter, new SillyDude(
                        _peopleCounter,
                        "Les Nuls",
                        "Crétins Fabuleux",
                        "Agad la té'évision é pis dors!\nAgad la té'évision é pis dors.\nAgad la té'évision é pis dors!\nAgad la té'évision é pis dors.\nAgad la té'évision é pis dors!\nAgad la té'évision é pis dors.\nAgad la té'évision é pis dors.\n",
#if LOCAL_DATA
                            "louis_ck.jpg",
#else
                        "https://www.jokeme.fr/images/les-nuls-JTN.jpg",
#endif
                        4,
                        "LesNuls",
                        "https://img.static-rmg.be/a/view/q75/w720/h480/2223699/un-clin-doeil-a-la-cite-de-la-peur-sur-le-site-de-2-24535-1433777643-0-dblbig-jpg.jpg",
                        "https://www.youtube.com/watch?v=lNEpFJYduto")
                },
            };

            for (int id = 1; id < 200; id++)
            {
                var dudeToClone = _Data[id];
                _Data.Add(++_peopleCounter, dudeToClone.Clone(_peopleCounter));
            }
        }
        public async Task<PageResult<SillyDude>> GetSillyPeoplePageAsync(int pageNumber, int pageSize)
        {
            await Task.Delay(TimeSpan.FromSeconds(pageNumber > 1 ? 1 : 3));
            return new PageResult<SillyDude>(
                _Data.Count,
                _Data.Values.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList());
        }
        private async Task<PageResult<SillyDude>> LoadSillyPeoplePageAsync(int pageNumber, int pageSize, bool isRefresh)
        {
            for (int i = 0; i < pageSize; i++)
            {

            }
            PageResult<SillyDude> resultPage = await GetSillyPeoplePageAsync(pageNumber, pageSize);
            var viewModels = resultPage.Items.Select(dude => new SillyDudeVmo(dude/*, GoToSillyDudeCommand*/)).ToList();

            if (isRefresh)
            {
                SillyPeople = new ObservableRangeCollection<SillyDudeVmo>();
            }
            foreach (var item in viewModels)
            {
                SillyPeople.Add(item);
            }
            //SillyPeople.AddRange(viewModels);

            // Uncomment to test CurrentIndex property
            // TaskMonitor.Create(
            //    async () =>
            //    {
            //        await Task.Delay(2000);
            //        CurrentIndex = 15;
            //    });

            // Uncomment to test Reset action
            // TaskMonitor.Create(
            //   async () =>
            //   {
            //       await Task.Delay(6000);
            //       SillyPeople.Clear();
            //       await Task.Delay(3000);
            //       SillyPeople = new ObservableRangeCollection<SillyDudeVmo>(viewModels);
            //   });

            return resultPage;
        }
        private ObservableCollection<SillyDudeVmo> _sillyPeople;
        public ObservableCollection<SillyDudeVmo> SillyPeople
        {
            get => _sillyPeople;
            set => SetAndRaise(ref _sillyPeople, value);
        }
        private string _title;
        public string Title
        {
            get => _title;
            set => SetAndRaise(ref _title, value);
        }
        public Paginator<SillyDude> SillyPeoplePaginator { get; }
        protected bool SetAndRaise<T>(ref T property, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(property, value))
            {
                return false;
            }

            property = value;
            RaisePropertyChanged(propertyName);
            return true;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged<T>(Expression<Func<T>> expression)
        {
            if (expression == null)
            {
                throw new ArgumentException("Getting property name form expression is not supported for this type.");
            }

            if (!(expression is LambdaExpression lamda))
            {
                throw new NotSupportedException(
                    "Getting property name form expression is not supported for this type.");
            }

            if (lamda.Body is MemberExpression memberExpression)
            {
                RaisePropertyChanged(memberExpression.Member.Name);
                return;
            }

            var unary = lamda.Body as UnaryExpression;
            if (unary?.Operand is MemberExpression member)
            {
                RaisePropertyChanged(member.Member.Name);
                return;
            }

            throw new NotSupportedException("Getting property name form expression is not supported for this type.");
        }

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            SillyPeople.Clear();
            SillyPeoplePaginator.LoadPage(1,false);
        }
    }
    public class SillyDudeVmo
    {
        public SillyDudeVmo(SillyDude dude/*, ICommand onItemTappedCommand*/)
        {
            if (dude != null)
            {
                Id = dude.Id;
                Name = dude.Name;
                FullName = dude.FullName;
                Role = dude.Role;
                Description = dude.Description;
                ImageUrl = dude.ImageUrl;
                SillinessDegree = dude.SillinessDegree;
                SourceUrl = dude.SourceUrl;
            }

            //OnItemTappedCommand = onItemTappedCommand;
        }

        public bool IsMovable { get; protected set; } = true;

        //public ICommand OnItemTappedCommand { get; set; }

        public int Id { get; }

        public string Name { get; }

        public string FullName { get; }

        public string Role { get; }

        public string Description { get; }

        public string ImageUrl { get; }

        public int SillinessDegree { get; }

        public string SourceUrl { get; }

        public void Lock()
        {
            IsMovable = false;
        }
    }
    public class SillyDude
    {
        private readonly string _realName;

        public SillyDude(int id, string name, string role, string description, string imageUrl, int sillinessDegree, string filmoMarkdown, string memeUrl, string sourceUrl = null)
        {
            if (sillinessDegree > 5 || sillinessDegree < 0)
            {
                throw new ArgumentException(@"sillinessDegree must be between 0 and 5", nameof(sillinessDegree));
            }

            Id = id;
            _realName = name;
            Role = role;
            Description = description;
            ImageUrl = imageUrl;
            SillinessDegree = sillinessDegree;
            SourceUrl = sourceUrl;
            FilmoMarkdown = filmoMarkdown;
            MemeUrl = memeUrl;
        }

        public int Id { get; }

#if INFINITE_LIST
        public string Name => $"{TruncateName(32)} n°{Id}";
#else
        public string Name => _realName;
#endif

        public string FullName => $"{_realName} n°{Id}";

        public string Role { get; }

        public string Description { get; }

        public string ImageUrl { get; }

        public int SillinessDegree { get; }

        public string SourceUrl { get; }

        public string FilmoMarkdown { get; set; }

        public string MemeUrl { get; }

        public SillyDude Clone(int id)
        {
            return new SillyDude(
                id,
                _realName,
                Role,
                Description,
                ImageUrl,
                SillinessDegree,
                FilmoMarkdown,
                MemeUrl,
                SourceUrl);
        }

        private string TruncateName(int maxChars)
        {
            return _realName.Length <= maxChars ? _realName : _realName.Substring(0, maxChars) + "...";
        }
    }
}
