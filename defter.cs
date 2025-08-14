using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAssis
{
    internal class defter
    {

        /*
         * Staj 16. Gün
Bugün mühendis ile stajımın son haftası olduğunu konuştuk. Kendisi, bu hafta boyunca yapmam için bir proje hazırladığını söyledi. Proje, akıllı ev sistemleri ile ilgiliydi. Sıcaklık, nem, kapı ve duman sensörlerinden oluşan bir sistem tasarlamam isteniyordu. Projede veri tabanı bağlantısı ve kullanıcı arayüzü (UI) olması gerektiği gibi, aynı zamanda thread kullanımı da talep edildi.

Thread konusuna yeterince hakim olmak için öncelikle araştırma yaptım ve basit thread örnekleri üzerinde çalıştım. Ardından sensörlerin bulunduğu sınıfı yazmaya başladım. Bu sınıfta if-else yapısı ile sensör değerlerini kontrol eden bir yapı kurdum.

Uygulama, Windows Form üzerinden geliştirilecek.

Kazanımlar:

Thread mantığını ve çoklu iş parçacığı kullanımının temelini öğrendim.

Basit thread örnekleri ile pratik yaparak mantığını pekiştirdim.

Sensör değerlerini kontrol eden sınıf yapısını oluşturmaya başladım.

Projede kullanılacak teknolojiler (Windows Form, veri tabanı, sensör sınıfları) hakkında genel planlama yaptım.






Staj 17. Gün
16. günden kaldığım yerden devam ettim ve yavaş yavaş UI (kullanıcı arayüzü) tasarımlarını yapmaya başladım. Planım, verileri veri tabanından DataGrid üzerine çekmek olduğu için öncelikle bu kısım üzerinde çalıştım.

Veri tabanı çalışmalarına başlamak amacıyla SQLite indirdim. Ardından DB Browser aracılığıyla tablo ve veri tabanı oluşturma işlemleri için yardım alarak ilk tablomu oluşturdum. Bu tablo, sensör verilerini göstermek için kullanılacak.

Tabloyu oluşturduktan sonra projeme veri tabanı bağlantısını sağlamak için çalışmalara başladım.

Kazanımlar:

SQLite kurulumu ve temel kullanımı hakkında bilgi sahibi oldum.

DB Browser ile tablo ve veri tabanı oluşturma adımlarını öğrendim.

Windows Forms projesinde veri tabanı bağlantısının nasıl sağlanacağını araştırmaya başladım.

UI tasarım sürecine giriş yaparak DataGrid yapılandırmasını planladım.








Staj 18. Gün
Artık proje yavaş yavaş şekillenmeye başladı. Sensörlerin çalıştığını ve hata durumlarını daha kolay anlamak için DataGrid üzerinde renklendirme yapmaya karar verdim. Planım, hata veren sütunları kırmızı renkle vurgulamaktı. Bu amaçla tek tek sensör değerlerini kontrol edip gerekli renklendirmeleri yaptım.

Devamında, projede tanımlandığı şekilde yalnızca hata veren satırları saat ve hata mesajı ile birlikte yeni bir tabloya kaydetmek için veri tabanına yazma işlemini gerçekleştirdim. Bu sırada, ana tabloda da renklendirme işlemlerine devam ettim.

Kazanımlar:

DataGrid üzerinde koşullu biçimlendirme (renklendirme) uygulamayı öğrendim.

Sensör hata durumlarını saat ve hata mesajıyla birlikte kayıt altına alacak yeni bir veri tablosu oluşturdum.

Aynı anda hem veri tabanına yazma hem de UI üzerinde görsel geri bildirim sağlama mantığını geliştirdim.

Hata durumlarının izlenebilirliğini artıracak bir yapı kurdum.





Staj 19. Gün
Bugün projeye gerekli butonları eklemeye başladım. Temel CRUD (Create, Read, Update, Delete) işlemlerini gerçekleştiren ve sensörlerin eşik değerlerini değiştiren butonları oluşturdum. Eşik değerlerin kaydedilebilmesi için yeni bir tablo tasarladım.

Thread yapısında veri üretme süresini değiştirdim; artık sensör verileri 10 saniyede bir üretiliyor. Butonlara hata ayıklama kontrolleri ekledim. Örneğin, aynı isimde sensör oluşturulamaması veya olmayan bir sensörün silinememesi gibi durumları engelleyen kontroller sağladım.

Kazanımlar:

Windows Forms’ta buton ekleme ve CRUD işlemleri gerçekleştirme pratiği kazandım.

Veri tabanına yeni bir tablo ekleyerek eşik değerleri kalıcı hale getirdim.

Thread zamanlamasını değiştirerek periyodik veri üretim aralığını optimize ettim.

Hata ayıklama mantığını geliştirerek veri tutarlılığını koruyacak kontroller ekledim.


         */
    }
}
