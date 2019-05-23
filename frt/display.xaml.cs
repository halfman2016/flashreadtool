using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Background;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System.Threading;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace frt
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class display : Page
    {
       private DispatcherTimer timer;//定义定时器
#pragma warning disable CS0414 // 字段“display.isshow”已被赋值，但从未使用过它的值
        private bool isshow = false;
        string txtdis;
        int tlines;
        int tlength;
        int linewidth;
        int readbite;
        int readmode;
        int bitetimes = 0;
        string before;
        string currentline;
        string currentline2;
        string after;
        List<string> lines = new List<string>();
#pragma warning restore CS0414 // 字段“display.isshow”已被赋值，但从未使用过它的值

        public display()
        {
            this.InitializeComponent();
                      
            if ((App.Current as App).maintxt=="")
            
            {
                txtdis = "当日地陷东南，这东南一隅有处曰姑苏，有城曰阊\n\r门者，最是红尘中一二等富\r\r贵风流之地。这阊门外有个十里街，街内有个仁清巷，巷内有个古庙，因地方窄狭，人皆\n\n呼作葫芦庙。庙旁住着一家乡宦，姓甄，名费，字士隐。嫡妻封氏，情性贤淑\r\n，深明礼义。家中虽不甚富贵，然本地便也推他为望族了。因这甄士隐禀性恬淡，不以\n\r功名为念，每日只以观花修竹、酌酒吟诗为乐，\n\r\n\r倒是神仙一流人品。只是一件不足：如今\r\n年已半百，膝下无儿，只有一女，乳名唤作英莲，年方三岁。\r\n\r\n\r\n\r\n\r\n\r\n\r\n 一日，炎夏永昼，士隐于书房闲坐，至手倦抛书，伏几少憩，不觉朦胧睡去。梦至一处，不辨是何地方。忽见那厢来了一僧一道，且行且谈。\r 只听道人问道：“你携了这蠢物，意欲何往？”那僧笑道：“你放心，如今现有一段风流公案正该了结，这一干风流冤家，尚未投胎入世。趁此机会，就将此蠢物夹带于中，使他去经历经历。”那道人道：“原来近日风流冤孽又将造劫历世去不成？但不知落于何方何处？”那僧笑道：“此事说来好笑，竟是千古未闻的罕事。只因西方灵河岸上三生石畔，有绛珠草一株，时有赤瑕宫神瑛侍者，日以甘露灌溉，这绛珠草始得久延岁月。后来既受天地精华，复得雨露滋养，遂得脱却草胎木质，得换人形，仅修成个女体，终日游于离恨天外，饥则食蜜青果为膳，渴则饮灌愁海水为汤。只因尚未酬报灌溉之德，故其五内便郁结着一段缠绵不尽之意。恰近日这神瑛侍者凡心偶炽，乘此昌明太平朝世，意欲下凡造历幻缘，已在警幻仙子案前挂了号。警幻亦曾问及，灌溉之情未偿，趁此倒可了结的。那绛珠仙子道：‘他是甘露之惠，我并无此水可还。他既下世为人，我也去下世为人，但把我一生所有的眼泪还他，也偿还得过他了。’因此一事，就勾出多少风流冤家来，陪他们去了结此案。”\r\n\r\n 那道人道：“果是罕闻。实未闻有还泪之说。想来这一段故事，比历来风月事故更加琐碎细腻了。”那僧道：“历来几个风流人物，不过传其大概以及诗词篇章而已；至家庭闺阁中一饮一食，总未述记。再者，大半风月故事，不过偷香窃玉，暗约私奔而已，并不曾将儿女之真情发泄一二。想这一干人入世，其情痴色鬼、贤愚不肖者，悉与前人传述不同矣。”那道人道：“趁此何不你我也去下世度脱几个，岂不是一场功德？”那僧道：“正合吾意，你且同我到警幻仙子宫中，将蠢物交割清楚，待这一干风流孽鬼下世已完，你我再去。如今虽已有一半落尘，然犹未全集。”道人道：“既如此，便随你去来。”\r\n\r\n 却说甄士隐俱听得明白，但不知所云“蠢物”系何东西。遂不禁上前施礼，笑问道：“二仙师请了。”那僧道也忙答礼相问。士隐因说道：“适闻仙师所谈因果，实人世罕闻者。但弟子愚浊，不能洞悉明白，若蒙大开痴顽，备细一闻，弟子则洗耳谛听，稍能警省，亦可免沉伦之苦。”二仙笑道：“此乃玄机不可预泄者。到那时不要忘我二人，便可跳出火坑矣。”士隐听了，不便再问。因笑道：“玄机不可预泄，但适云‘蠢物’，不知为何，或可一见否？”那僧道：“若问此物，倒有一面之缘。”说着，取出递与士隐。\n    士隐接了看时，原来是块鲜明美玉，上面字迹分明，镌着“通灵宝玉”四字，后面还有几行小字。正欲细看时，那僧便说已到幻境，便强从手中夺了去，与道人竟过一大石牌坊，上书四个大字，乃是“太虚幻境”。两边又有一幅对联，道是：\r\n\r\n    假作真时真亦假，无为有处有还无。\r\n\r\n    士隐意欲也跟了过去，方举步时，忽听一声霹雳，有若山崩地陷。士隐大叫一声，定睛一看，只见烈日炎炎，芭蕉冉冉，所梦之事便忘了大半。又见奶母正抱了英莲走来。士隐见女儿越发生得粉妆玉琢，乖觉可喜，便伸手接来，抱在怀内，斗他顽耍一回，又带至街前，看那过会的热闹。\r\n\r\n    方欲进来时，只见从那边来了一僧一道：那僧则癞头跣脚，那道则跛足蓬头，疯疯癫癫，挥霍谈笑而至。及至到了他门前，看见士隐抱着英莲，那僧便大哭起来，又向士隐道：“施主，你把这有命无运、累及爹娘之物，抱在怀内作甚？”士隐听了，知是疯话，也不去睬他。那僧还说：“舍我罢，舍我罢！”士隐不耐烦，便抱女儿撤身要进去，那僧乃指着他大笑，口内念了四句言词道：\r\n\r\n    惯养娇生笑你痴，菱花空对雪澌澌。\r\n\r\n    好防佳节元宵后，便是烟消火灭时。\r\n\r\n    士隐听得明白，心下犹豫，意欲问他们来历。只听道人说道：“你我不必同行，就此分手，各干营生去罢。三劫后，我在北邙山等你，会齐了同往太虚幻境销号。”那僧道：“最妙，最妙！”说毕，二人一去，再不见个踪影了。士隐心中此时自忖：这两个人必有来历，该试一问，如今悔却晚也。\r\n\r\n    这士隐正痴想，忽见隔壁葫芦庙内寄居的一个穷儒──姓贾名化、表字时飞、别号雨村者走了出来。这贾雨村原系胡州人氏，也是诗书仕宦之族，因他生于末世，父母祖宗根基已尽，人口衰丧，只剩得他一身一口，在家乡无益，因进京求取功名，再整基业。自前岁来此，又淹蹇住了，暂寄庙中安身，每日卖字作文为生，故士隐常与他交接。\r\n\r\n    当下雨村见了士隐，忙施礼陪笑道：“老先生倚门伫望，敢是街市上有甚新闻否？”士隐笑道：“非也。适因小女啼哭，引他出来作耍，正是无聊之甚，兄来得正妙，请入小斋一谈，彼此皆可消此永昼。”说着，便令人送女儿进去，自与雨村携手来至书房中。小童献茶。方谈得三五句话，忽家人飞报：“严老爷来拜。”士隐慌的忙起身谢罪道：“恕诳驾之罪，略坐，弟即来陪。”雨村忙起身亦让道：“老先生请便。晚生乃常造之客，稍候何妨。”说着，士隐已出前厅去了。\r\n\r\n    这里雨村且翻弄书籍解闷。忽听得窗外有女子嗽声，雨村遂起身往窗外一看，原来是一个丫鬟，在那里撷花，生得仪容不俗，眉目清明，虽无十分姿色，却亦有动人之处。雨村不觉看的呆了。\r\n\r\n    那甄家丫鬟撷了花，方欲走时，猛抬头见窗内有人，敝巾旧服，虽是贫窘，然生得腰圆背厚，面阔口方，更兼剑眉星眼，直鼻权腮。这丫鬟忙转身回避，心下乃想：“这人生的这样雄壮，却又这样褴褛，想他定是我家主人常说的什么贾雨村了，每有意帮助周济，只是没甚机会。我家并无这样贫窘亲友，想定是此人无疑了。怪道又说他必非久困之人。”如此想来，不免又回头两次。雨村见他回了头，便自为这女子心中有意于他，便狂喜不尽，自为此女子必是个巨眼英雄，风尘中之知己也。一时小童进来，雨村打听得前面留饭，不可久待，遂从夹道中自便出门去了。士隐待客既散，知雨村自便，也不去再邀。\r\n\r\n    一日，早又中秋佳节。士隐家宴已毕，乃又另具一席于书房，却自己步月至庙中来邀雨村。原来雨村自那日见了甄家之婢曾回顾他两次，自为是个知己，便时刻放在心上。今又正值中秋，不免对月有怀，因而口占五言一律云：\r\n\r\n    未卜三生愿，频添一段愁。\r\n\r\n    闷来时敛额，行去几回头。\r\n\r\n    自顾风前影，谁堪月下俦？\r\n\r\n    蟾光如有意，先上玉人楼。\r\n\r\n    雨村吟罢，因又思及平生抱负，苦未逢时，乃又搔首对天长叹，复高吟一联曰：\r\n\r\n    玉在椟中求善价，钗于奁内待时飞。\r\n\r\n    恰值士隐走来听见，笑道：“雨村兄真抱负不浅也！”雨村忙笑道：“不过偶吟前人之句，何敢狂诞至此。”因问：“老先生何兴至此？”士隐笑道：“今夜中秋，俗谓‘团圆之节’，想尊兄旅寄僧房，不无寂寥之感，故特具小酌，邀兄到敝斋一饮，不知可纳芹意否？”雨村听了，并不推辞，便笑道：“既蒙厚爱，何敢拂此盛情。”说着，便同士隐复过这边书院中来。\r\n\r\n    须臾茶毕，早已设下杯盘，那美酒佳肴自不必说。二人归坐，先是款斟漫饮，次渐谈至兴浓，不觉飞觥限斝起来。当时街坊上家家箫管，户户弦歌，当头一轮明月，飞彩凝辉，二人愈添豪兴，酒到杯干。雨村此时已有七八分酒意，狂兴不禁，乃对月寓怀，口号一绝云：\r\n\r\n    时逢三五便团圆，满把晴光护玉栏。\r\n\r\n    天上一轮才捧出，人间万姓仰头看。\r\n\r\n    士隐听了，大叫：“妙哉！吾每谓兄必非久居人下者，今所吟之句，飞腾之兆已见，不日可接履于云霓之上矣。可贺，可贺！”乃亲斟一斗为贺。雨村因干过，叹道：“非晚生酒后狂言，若论时尚之学，晚生也或可去充数沽名，只是目今行囊路费一概无措，神京路远，非赖卖字撰文即能到者。”士隐不待说完，便道：“兄何不早言。愚每有此心，但每遇兄时，兄并未谈及，愚故未敢唐突。今既及此，愚虽不才，‘义利’二字却还识得。且喜明岁正当大比，兄宜作速入都，春闱一战，方不负兄之所学也。其盘费馀事，弟自代为处置，亦不枉兄之谬识矣！”当下即命小童进去，速封五十两白银，并两套冬衣。又云：“十九日乃黄道之期，兄可即买舟西上，待雄飞高举，明冬再晤，岂非大快之事耶！”雨村收了银衣，不过略谢一语，并不介意，仍是吃酒谈笑。那天已交了三更，二人方散。\r\n\r\n    士隐送雨村去后，回房一觉，直至红日三竿方醒。因思昨夜之事，意欲再写两封荐书与雨村带至神都，使雨村投谒个仕宦之家为寄足之地。因使人过去请时，那家人去了回来说：“和尚说，贾爷今日五鼓已进京去了，也曾留下话与和尚转达老爷，说‘读书人不在黄道黑道，总以事理为要，不及面辞了。’”士隐听了，也只得罢了。\r\n\r\n    真是闲处光阴易过，倏忽又是元宵佳节矣。士隐命家人霍启抱了英莲去看社火花灯，半夜中，霍启因要小解，便将英莲放在一家门槛上坐着。待他小解完了来抱时，那有英莲的踪影？急得霍启直寻了半夜，至天明不见，那霍启也就不敢回来见主人，便逃往他乡去了。那士隐夫妇，见女儿一夜不归，便知有些不妥，再使几人去寻找，回来皆云连音响皆无。夫妻二人，半世只生此女，一旦失落，岂不思想，因此昼夜啼哭，几乎不曾寻死。看看的一月，士隐先就得了一病，当时封氏孺人也因思女构疾，日日请医疗治。\r\n\r\n    不想这日三月十五，葫芦庙中炸供，那些和尚不加小心，致使油锅火逸，便烧着窗纸。此方人家多用竹篱木壁者，大抵也因劫数，于是接二连三，牵五挂四，将一条街烧得如火焰山一般。彼时虽有军民来救，那火已成了势，如何救得下？直烧了一夜，方渐渐的熄去，也不知烧了几家。只可怜甄家在隔壁，早已烧成一片瓦砾场了。只有他夫妇并几个家人的性命不曾伤了。急得士隐惟跌足长叹而已。只得与妻子商议，且到田庄上去安身。偏值近年水旱不收，鼠盗蜂起，无非抢田夺地，鼠窃狗偷，民不安生，因此官兵剿捕，难以安身。士隐只得将田庄都折变了，便携了妻子与两个丫鬟投他岳丈家去。\r\n\r\n    他岳丈名唤封肃，本贯大如州人氏，虽是务农，家中都还殷实。今见女婿这等狼狈而来，心中便有些不乐。幸而士隐还有折变田地的银子未曾用完，拿出来托他随分就价薄置些须房地，为后日衣食之计。那封肃便半哄半赚，些须与他些薄田朽屋。士隐乃读书之人，不惯生理稼穑等事，勉强支持了一二年，越觉穷了下去。封肃每见面时，便说些现成话，且人前人后又怨他们不善过活，只一味好吃懒作等语。士隐知投人不着，心中未免悔恨，再兼上年惊唬，急忿怨痛，已有积伤，暮年之人，贫病交攻，竟渐渐的露出那下世的光景来。\r\n\r\n    可巧这日拄了拐杖挣挫到街前散散心时，忽见那边来了一个跛足道人，疯癫落脱，麻屣鹑衣，口内念着几句言词，道是：\r\n\r\n    世人都晓神仙好，惟有功名忘不了！\r\n\r\n    古今将相在何方？荒冢一堆草没了。\r\n\r\n    世人都晓神仙好，只有金银忘不了！\r\n\r\n    终朝只恨聚无多，及到多时眼闭了。\r\n\r\n    世人都晓神仙好，只有姣妻忘不了！\r\n\r\n    君生日日说恩情，君死又随人去了。\r\n\r\n    世人都晓神仙好，只有儿孙忘不了！\r\n\r\n    痴心父母古来多，孝顺儿孙谁见了？\r\n\r\n    士隐听了，便迎上来道：“你满口说些什么？只听见些‘好’‘了’‘好’‘了’。”那道人笑道：“你若果听见‘好’‘了’二字，还算你明白。可知世上万般，好便是了，了便是好。若不了，便不好；若要好，须是了。我这歌儿，便名《好了歌》”士隐本是有宿慧的，一闻此言，心中早已彻悟。因笑道：“且住！待我将你这《好了歌》解注出来何如？”道人笑道：“你解，你解。”士隐乃说道：\r\n\r\n    陋室空堂，当年笏满床，衰草枯杨，曾为歌舞场。\r\n";
                
            }
            else
            {
                txtdis = (App.Current as App).maintxt;
            }
            lines.Clear();
            tlength = txtdis.Length;
            readbite = (App.Current as App).readbite;
            readmode = (App.Current as App).readmode;
            //switch (readmode)
            //{
            //    case 20:
            //        break;
            //    case 
            //}
            txtdisplay.TextWrapping = TextWrapping.Wrap;
            txtdisplay.FontSize = (App.Current as App).fontsize;

            char[] ss = new char[5];
            ss[0] = 'q';
        }

        private void Timer_Tick(object sender, object e)
        {
            //if ((bitetimes+1) * linewidth < tlength)
            //{
            //    if (bitetimes == 0)
            //    { before = "";
            //    }
            //    else
            //    {
            //        currentline = lines.ElementAt(bitetimes);
            //        after = txtdis.Substring((bitetimes + 1) * linewidth);
            //        textdisplyonce(before, currentline, after);

            //        //TextPointer tps = TextPointer(bitetimes * linewidth, 1);

            //        //txtdisplay.Select(bitetimes * linewidth, bitetimes * linewidth + linewidth);
            //        scroll1.ChangeView(null, txtdisplay.FontSize * bitetimes, null);

            //    }
            //    bitetimes++;


            //}
            if (bitetimes < txtdisplay.Inlines.Count) {
                SolidColorBrush myBrush = new SolidColorBrush(Colors.Red);
                (txtdisplay.Inlines.ElementAt(bitetimes) as  Run).Foreground=myBrush;
                scroll1.ChangeView(null, txtdisplay.FontSize * bitetimes, null);
                bitetimes++;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            linewidth = (int)(1278 / (App.Current as App).fontsize);

            char[] tmpstr = new char[linewidth];
            int inlinesign = 0;
            txtdisplay.Inlines.Clear();
           
            
            for (int i = 0; i < txtdis.Length; i++)
            {
                char tmpchar = txtdis.ElementAt(i);

                if (tmpchar == '\r' || tmpchar == '\n')
                {
                    if (tmpchar == '\n' && txtdis.ElementAt(i - 1) == '\r' && i >= 1)
                    {
                        //删掉目前的 \n 进入下一个循环 啥也不用做，上一i做完了

                    }
                    else
                    {
                        //新行,换行符
                        Run run = new Run();
                        lines.Add(new string(tmpstr));
                        run.Text = lines.Last() + "\r";
                        txtdisplay.Inlines.Add(run);
                        inlinesign = 0;
                        tmpstr = new char[linewidth];
                        
                    }


                }
                else
                {
                    //字符加入tmp 
                    if (inlinesign < linewidth)
                    {
                        tmpstr[inlinesign] = tmpchar;
                        inlinesign++;
                    }
                    else
                    {
                        //一行完成
                        Run run = new Run();
                        lines.Add(new string(tmpstr));
                        run.Text = lines.Last()+ "\r\n";
                        txtdisplay.Inlines.Add(run);

                        inlinesign = 0;
                        tmpstr = new char[linewidth];
                        tmpstr[inlinesign] = tmpchar;
                    }
                }
            }


            TimeTrigger hourlyTrigger = new TimeTrigger(60, false);
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(readbite);
            timer.Tick += Timer_Tick;//每秒触发这个事件，以刷新指针
            timer.Start();



        }
       
    }
}
