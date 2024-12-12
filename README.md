# .NET Backend Geliştirici Projesi
<br>
Proje Açıklaması:<br>
Bu proje, Botano Technologies işe alım süreci kapsamında geliştirilmiştir. Proje, bir kart yönetim yapısı için bir API içermektedir ve aşağıdaki gereksinimlere göre hazırlanmıştır.
<br><br>
Teknolojiler ve Araçlar: <br>
 - .NET 8 CQRS mimarisi<br>
 - Entity Framework Core<br>
 - Fluent Validation<br>
 - AutoMapper <br>
 - MediatR<br>
 - JwtBearer<br>
 - PostgreSQL<br>
 - Swagger<br>

Özellikler;<br>
GUID Kullanımı: ID alanları için GUID tercih edilmiş ve sıralı GUID kullanılmıştır.
GUID: Global benzersizlik sağlar, güvenlidir, dağıtık sistemler için uygundur.
Sıralı GUID(SequentialGuidValueGenerator): Daha iyi performans ve daha az veritabanı parçalanması.

Veritabanı:<br> 
PostgreSQL için uzak sunucu kullanılmıştır. Bağlantı bilgileri, API projesinin appsettings.json dosyasında bulunmaktadır.

Enum Kullanımı: CardStatus enum olarak ayarlanmıştır, bu şekilde
Tip Güvenli hale gelmiştir, Belirli bir set içerisindeki değerlerle sınırlandırılmıştır.

API Endpoint'leri:<br>
POST : Yeni kart ekler. Karta ait tüm veri JSON formatında gönderilir.
PUT  : Mevcut kartı günceller.
GET  : api/card: Tüm kartları listeler. Karta ait tüm veri döndürülür.
GET  : api/card/{id}: Belirli bir kartın detayını getirir. Karta ait tüm veri döndürülür.

Ekstralar (Opsiyonel)<br>
Basit kullanıcı giriş ve kayıt API Endpoint'leri eklenmiştir. JWT ile kimlik doğrulaması sağlanmaktadır.

Kartları "done" duruma çekmek için bir API Endpoint eklenmiştir. Bu Endpoint'e istek atabilmek için giriş yapmak zorunludur. Tüm aktif kartlar tüm kullanıcılar tarafından cevaplanabilir. Çoktan çoğa ilişki kurulmuştur. Bir karttaki tüm sorular cevaplandığında, o kartın durumu "done" olarak güncellenir.

Varsayımlar ve Kararlar<br>
Görev dökümanında örnek veride card id, questions id ve choices id alanları bulunmamaktaydı; bu alanlar, kartların işleme tabi tutulabilmesi için eklenmiştir. Bu eklemeler, frontend geliştirici için yapılmıştır.

Test Kullanıcı Bilgileri;<br>
Sisteme login olmak için test kullanıcı ile giriş yapabilir veya yeni kayıt oluşturabilirsiniz.
Test User;
Email: codi@gmail.com
Password: 123

Proje Yükleme ve Erişim<br>
Proje, GitHub hesabım olan smtdeveloper'a private olarak yüklenmiştir ve admin@botano.com e-posta adresine erişim sağlanmıştır.
