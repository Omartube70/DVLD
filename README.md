# 🚦 نظام إدارة رخص القيادة والمركبات (DVLD)

<div align="center" dir="rtl">

![عرض توضيحي للنظام](https://github.com/Omartube70/DVLD/blob/master/DVLD.gif)

[![.NET Framework](https://img.shields.io/badge/.NET%20Framework-4.8-512BD4?style=for-the-badge&logo=.net&logoColor=white)](https://dotnet.microsoft.com/)
[![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)](https://www.microsoft.com/en-us/sql-server)
[![Windows Forms](https://img.shields.io/badge/Windows%20Forms-0078D6?style=for-the-badge&logo=windows&logoColor=white)](https://docs.microsoft.com/en-us/dotnet/desktop/winforms/)

**نظام مكتبي شامل لإدارة رخص القيادة وتسجيل المركبات**

[المميزات](#-المميزات) • [المعمارية](#️-المعمارية) • [التثبيت](#-التثبيت) • [التقنيات](#-التقنيات-المستخدمة)

</div>

---

## 📋 جدول المحتويات

- [نظرة عامة](#-نظرة-عامة)
- [المميزات](#-المميزات)
- [المعمارية](#️-المعمارية)
- [التقنيات المستخدمة](#-التقنيات-المستخدمة)
- [التثبيت](#-التثبيت)
- [الاستخدام](#-الاستخدام)
- [قاعدة البيانات](#️-قاعدة-البيانات)
- [المساهمة](#-المساهمة)
- [الترخيص](#-الترخيص)
- [التواصل](#-التواصل)

---

## 🌟 نظرة عامة

**نظام DVLD (إدارة رخص القيادة والمركبات)** هو تطبيق سطح مكتب قوي مبني باستخدام C# و .NET Framework يقوم بأتمتة وإدارة جميع العمليات المتعلقة بإصدار وتجديد رخص القيادة في إدارة مرور افتراضية.

تم بناء النظام على أساس **معمارية الطبقات الثلاث**، مما يجعله قوياً ومنظماً وسهل الصيانة والتطوير في المستقبل.

### 🎯 أبرز الميزات

- ✅ **نظام دخول آمن** مع التحكم في الصلاحيات حسب الأدوار
- ✅ **إدارة شاملة للرخص** (محلية ودولية)
- ✅ **نظام اختبارات متعدد** (اختبار النظر، النظري، العملي)
- ✅ **تتبع الطلبات** لجميع أنواع الرخص
- ✅ **واجهة سهلة الاستخدام** مع تنقل بديهي
- ✅ **معمارية قابلة للتوسع** تتبع أفضل الممارسات

---

## 🚀 المميزات

<div dir="rtl">

<table>
  <tr>
    <td width="50%">
      
### 👥 إدارة المستخدمين
- نظام تسجيل دخول آمن مع تشفير كلمات المرور
- التحكم في الصلاحيات حسب الأدوار
- تتبع نشاط المستخدمين
- إمكانية تغيير كلمة المرور
- تفعيل/إلغاء تفعيل الحسابات

    </td>
    <td width="50%">
      
### 👤 إدارة الأشخاص
- إضافة وتعديل وحذف سجلات الأشخاص
- إمكانيات بحث متقدمة
- دعم رفع المستندات
- تتبع الجنسيات
- إدارة كاملة للملفات الشخصية

    </td>
  </tr>
  <tr>
    <td width="50%">
      
### 📝 معالجة الطلبات
- طلبات رخص القيادة المحلية
- طلبات الرخص الدولية
- طلبات تجديد الرخص
- استبدال الرخص المفقودة/التالفة
- تتبع حالة الطلبات

    </td>
    <td width="50%">
      
### 🎓 إدارة الاختبارات
- جدولة اختبار النظر
- جدولة الاختبار النظري
- جدولة الاختبار العملي
- تسجيل نتائج الاختبارات
- إدارة إعادة الاختبارات
- تتبع مواعيد الاختبارات

    </td>
  </tr>
  <tr>
    <td width="50%">
      
### 🪪 عمليات الرخص
- إصدار رخص جديدة
- تجديد الرخص المنتهية
- استبدال الرخص المفقودة/التالفة
- حجز الرخص
- إطلاق الرخص المحجوزة
- تتبع سجل الرخص

    </td>
    <td width="50%">
      
### 📊 التقارير والتحليلات
- تقارير الطلبات
- إحصائيات الرخص
- تحليل نتائج الاختبارات
- سجلات نشاط المستخدمين
- مسارات تدقيق النظام

    </td>
  </tr>
</table>

</div>

---

## 🏗️ المعمارية

<div dir="rtl">

يتبع المشروع نمط **معمارية الطبقات الثلاث** لفصل الاهتمامات وتنظيم الكود:

### 📦 تفصيل الطبقات

<table dir="rtl">
  <tr>
    <th width="20%">الطبقة</th>
    <th width="30%">المسؤولية</th>
    <th width="50%">المكونات</th>
  </tr>
  <tr>
    <td><strong>🖥️ طبقة العرض</strong><br/><code>DVLD</code></td>
    <td>واجهة المستخدم والتفاعل</td>
    <td>
      • Windows Forms<br/>
      • عناصر التحكم<br/>
      • التحقق من المدخلات<br/>
      • ربط البيانات
    </td>
  </tr>
  <tr>
    <td><strong>⚙️ طبقة منطق الأعمال</strong><br/><code>DVLD_Business</code></td>
    <td>قواعد ومنطق الأعمال</td>
    <td>
      • كائنات الأعمال<br/>
      • قواعد التحقق<br/>
      • معالجة البيانات<br/>
      • إدارة سير العمل
    </td>
  </tr>
  <tr>
    <td><strong>💾 طبقة الوصول للبيانات</strong><br/><code>DVLD_DataAccess</code></td>
    <td>عمليات قاعدة البيانات</td>
    <td>
      • ADO.NET<br/>
      • استعلامات SQL<br/>
      • الإجراءات المخزنة<br/>
      • إدارة الاتصالات
    </td>
  </tr>
</table>

</div>

---

## 🛠️ التقنيات المستخدمة

<div align="center">

| الفئة | التقنية |
|-------|---------|
| **لغة البرمجة** | ![C#](https://img.shields.io/badge/C%23-239120?style=flat&logo=c-sharp&logoColor=white) |
| **إطار العمل** | ![.NET](https://img.shields.io/badge/.NET%20Framework%204.8-512BD4?style=flat&logo=.net&logoColor=white) |
| **واجهة المستخدم** | ![Windows Forms](https://img.shields.io/badge/Windows%20Forms-0078D6?style=flat&logo=windows&logoColor=white) |
| **قاعدة البيانات** | ![SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927?style=flat&logo=microsoft-sql-server&logoColor=white) |
| **الوصول للبيانات** | ![ADO.NET](https://img.shields.io/badge/ADO.NET-512BD4?style=flat&logo=.net&logoColor=white) |
| **الأمان** | ![BCrypt](https://img.shields.io/badge/BCrypt-323330?style=flat&logo=lock&logoColor=white) |

</div>

---

## 💻 التثبيت

<div dir="rtl">

### 📋 المتطلبات الأساسية

قبل البدء، تأكد من تثبيت ما يلي:

- ![Visual Studio](https://img.shields.io/badge/Visual%20Studio%202019+-5C2D91?style=flat&logo=visual-studio&logoColor=white) أو أحدث
- ![SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927?style=flat&logo=microsoft-sql-server&logoColor=white) (2016 أو أحدث)
- ![.NET Framework](https://img.shields.io/badge/.NET%20Framework%204.8-512BD4?style=flat&logo=.net&logoColor=white)

### 🔧 خطوات التثبيت

#### 1️⃣ استنساخ المستودع

</div>
```bash
git clone https://github.com/Omartube70/DVLD.git
cd DVLD
```

<div dir="rtl">

#### 2️⃣ إعداد قاعدة البيانات

1. افتح **SQL Server Management Studio (SSMS)**
2. أنشئ قاعدة بيانات جديدة باسم `DVLD`
3. حدد موقع ملف السكريبت: `Database/DVLD_Database.sql`
4. قم بتنفيذ السكريبت لإنشاء الجداول والإجراءات المخزنة وبيانات البداية

</div>
```sql
-- نفذ في SSMS
USE master;
GO

CREATE DATABASE DVLD;
GO

USE DVLD;
GO

-- قم بتشغيل سكريبت DVLD_Database.sql هنا
```

<div dir="rtl">

#### 3️⃣ تكوين سلسلة الاتصال

1. افتح ملف الحل `DVLD.sln` في Visual Studio
2. انتقل إلى مشروع **DVLD**
3. افتح ملف `App.Config`
4. قم بتحديث سلسلة الاتصال في قسم `<connectionStrings>`:

</div>
```xml
<connectionStrings>
    <add name="DvldDb" 
         connectionString="Server=YOUR_SERVER_NAME;Database=DVLD;Integrated Security=True;" 
         providerName="System.Data.SqlClient" />
</connectionStrings>
```

<div dir="rtl">

**أسماء الخوادم الشائعة:**
- `.` (المثيل الافتراضي المحلي)
- `localhost`
- `(localdb)\MSSQLLocalDB` (LocalDB)
- `YOUR_COMPUTER_NAME\SQLEXPRESS`

**ملاحظة:** الكود الحالي يقوم بقراءة سلسلة الاتصال من ملف `App.Config` كالتالي:

</div>
```csharp
using System;
using System.Configuration;

namespace DVLD_DataAccess
{
    static class clsDataAccessSettings
    {
        public static string ConnectionString = 
            ConfigurationManager.ConnectionStrings["DvldDb"].ConnectionString;
    }
}
```

<div dir="rtl">

#### 4️⃣ البناء والتشغيل

1. قم ببناء الحل: `Ctrl + Shift + B`
2. اجعل مشروع `DVLD` مشروع البدء
3. قم بتشغيل التطبيق: `F5`

### 🔐 بيانات تسجيل الدخول الافتراضية

</div>
```
اسم المستخدم: Admin
كلمة المرور: 1234
```

<div dir="rtl">

> ⚠️ **ملاحظة أمنية:** قم بتغيير كلمة المرور الافتراضية بعد أول تسجيل دخول!

</div>

---

## 📖 الاستخدام

<div dir="rtl">

### 🚪 البدء

1. **تسجيل الدخول** باستخدام بيانات الاعتماد الخاصة بك
2. التنقل عبر **القائمة الرئيسية** للوصول إلى الوحدات المختلفة
3. استخدم وظيفة **البحث** للعثور على السجلات الموجودة
4. إنشاء **طلبات جديدة** لمعالجة الرخص
5. تتبع **حالة الطلب** عبر سير العمل

### 📊 سير العمل الشائع

<details>
<summary><b>🆕 طلب رخصة جديدة</b></summary>

1. انتقل إلى **الطلبات** ← **رخصة قيادة جديدة** ← **رخصة محلية**
2. حدد أو أنشئ **سجل شخص**
3. اختر **فئة الرخصة**
4. ادفع **رسوم الطلب**
5. حدد موعد **اختبار النظر**
6. أكمل جميع **الاختبارات** المطلوبة
7. **إصدار الرخصة** عند اجتياز جميع الاختبارات

</details>

<details>
<summary><b>🔄 تجديد رخصة موجودة</b></summary>

1. انتقل إلى **الطلبات** ← **تجديد رخصة القيادة**
2. ابحث عن **الرخصة الموجودة**
3. تحقق من **تفاصيل الرخصة**
4. ادفع **رسوم التجديد**
5. **إصدار الرخصة المجددة**

</details>

<details>
<summary><b>🌍 رخصة دولية</b></summary>

1. انتقل إلى **الطلبات** ← **رخصة دولية جديدة**
2. حدد **رخصة محلية نشطة**
3. ادفع **رسوم الطلب**
4. **إصدار الرخصة الدولية**

</details>

</div>

---

## 🗄️ قاعدة البيانات

<div dir="rtl">

<details>
<summary><b>📊 الجداول الرئيسية</b></summary>

### الجداول الأساسية

- **People** - المعلومات الشخصية
- **Users** - مستخدمو النظام وبيانات الاعتماد
- **Applications** - بيانات الطلبات الأساسية
- **LocalDrivingLicenseApplications** - طلبات الرخص المحلية
- **InternationalLicenses** - سجلات الرخص الدولية
- **Licenses** - الرخص الصادرة
- **Drivers** - معلومات السائقين
- **Tests** - سجلات الاختبارات
- **TestAppointments** - جدولة الاختبارات
- **DetainedLicenses** - تتبع الرخص المحجوزة

### جداول البحث

- **Countries** - البيانات الرئيسية للدول
- **ApplicationTypes** - تعريفات أنواع الطلبات
- **TestTypes** - تعريفات أنواع الاختبارات
- **LicenseClasses** - تعريفات فئات الرخص

</details>

</div>

---

## 🤝 المساهمة

<div dir="rtl">

المساهمات مرحب بها! إليك كيف يمكنك المساعدة:

### 🌟 طرق المساهمة

- 🐛 الإبلاغ عن الأخطاء
- 💡 اقتراح ميزات جديدة
- 📝 تحسين الوثائق
- 🔧 إرسال طلبات السحب

### 📝 إرشادات المساهمة

1. **انسخ** المستودع (Fork)
2. **أنشئ** فرع ميزة (`git checkout -b feature/AmazingFeature`)
3. **أرسل** تغييراتك (`git commit -m 'Add some AmazingFeature'`)
4. **ادفع** إلى الفرع (`git push origin feature/AmazingFeature`)
5. **افتح** طلب سحب (Pull Request)

### 🐛 الإبلاغ عن المشاكل

عند الإبلاغ عن المشاكل، يرجى تضمين:

- وصف واضح للمشكلة
- خطوات إعادة الإنتاج
- السلوك المتوقع مقابل الفعلي
- لقطات الشاشة (إن أمكن)
- تفاصيل البيئة (نظام التشغيل، إصدار .NET، إصدار SQL Server)

</div>

---

## 📄 الترخيص

<div dir="rtl">

هذا المشروع مرخص بموجب **ترخيص MIT** - انظر ملف [LICENSE](LICENSE) للتفاصيل.

</div>
```
ترخيص MIT

حقوق النشر (c) 2024 عمر

يُمنح بموجب هذا إذن مجاني لأي شخص يحصل على نسخة
من هذا البرنامج والملفات الوثائقية المرتبطة ("البرنامج")، للتعامل
في البرنامج دون قيود، بما في ذلك على سبيل المثال لا الحصر الحقوق
في الاستخدام والنسخ والتعديل والدمج والنشر والتوزيع والترخيص من الباطن و/أو بيع
نسخ من البرنامج، والسماح للأشخاص الذين يتم تزويدهم بالبرنامج
بذلك، مع مراعاة الشروط التالية:

يجب تضمين إشعار حقوق النشر أعلاه وهذا الإشعار بالإذن في جميع
النسخ أو الأجزاء الكبيرة من البرنامج.
```

---

## 📧 التواصل

<div align="center">

  **Omar Mohamed**

[![GitHub](https://img.shields.io/badge/GitHub-100000?style=for-the-badge&logo=github&logoColor=white)](https://github.com/Omartube70)
[![LinkedIn](https://img.shields.io/badge/LinkedIn-0077B5?style=for-the-badge&logo=linkedin&logoColor=white)](https://linkedin.com/in/yourprofile)
[![Email](https://img.shields.io/badge/Email-D14836?style=for-the-badge&logo=gmail&logoColor=white)](mailto:your.email@example.com)

**رابط المشروع:** [https://github.com/Omartube70/DVLD](https://github.com/Omartube70/DVLD)

</div>

---

<div align="center" dir="rtl">

### ⭐ إذا وجدت هذا المشروع مفيداً، يرجى منحه نجمة!

صُنع بـ ❤️ بواسطة [عمر محمد](https://github.com/Omartube70)

![Visitors](https://visitor-badge.laobi.icu/badge?page_id=Omartube70.DVLD)

</div>

---

## 🙏 شكر وتقدير

<div dir="rtl">

- الأيقونات من [Font Awesome](https://fontawesome.com/)
- الشارات من [Shields.io](https://shields.io/)
- إلهام README من [Best-README-Template](https://github.com/othneildrew/Best-README-Template)

</div>

---

<div align="center">

**[⬆ العودة إلى الأعلى](#-نظام-إدارة-رخص-القيادة-والمركبات-dvld)**

</div>
