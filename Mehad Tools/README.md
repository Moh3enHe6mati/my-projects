# Mehad Tools - راهنمای جامع رابط کاربری و عملکرد

## 📋 نمای کلی

**Mehad Tools** یک نرم‌افزار پیشرفته برای پردازش فایل‌های اسکریپت تشخیصی خودرو (.jc) و تبدیل آنها به فایل‌های قابل استفاده در شبیه‌سازهای تشخیصی (.frm و .sim) است. این نرم‌افزار دارای رابط کاربری تب‌محور با عملکردهای متنوع برای پردازش پروتکل‌های مختلف KWP و CAN است.

## 🎯 ساختار رابط کاربری

### 📊 تب‌ها (Tabs)

نرم‌افزار دارای چندین تب اصلی است:

#### تب 1: تب اصلی (اندازه عادی)
- **ابعاد**: 600x400 پیکسل
- **عرض تب**: 576 پیکسل
- **ارتفاع تب**: 340 پیکسل

#### تب 2 و 3: تب‌های پیشرفته (اندازه بزرگ)
- **ابعاد**: 900x600 پیکسل
- **عرض تب**: 875 پیکسل
- **ارتفاع تب**: 540 پیکسل
- **ویژگی**: `resultlabel` مخفی می‌شود

### 🔄 تغییر خودکار اندازه
```csharp
// تب 2 یا 3 انتخاب شد → اندازه بزرگ
if (tabControl1.SelectedIndex == 2 || tabControl1.SelectedIndex == 3)

// تب‌های دیگر → اندازه عادی
else
```

## 🎛 کنترل‌های اصلی

### 📝 TextBox - جعبه متن (converttextBox)
**موقعیت**: تب اصلی
**عملکرد**: ورودی داده‌های هگز، ASCII، باینری
**ویژگی‌ها**:
- پاک کردن با دکمه `convertclear`
- ورودی برای تبدیل فرمت‌ها
- نمایش نتایج تبدیل

### 🏷 Label - برچسب وضعیت (resultlabel)
**موقعیت**: پایین پنجره
**عملکرد**: نمایش وضعیت عملیات
**رنگ‌ها**:
- 🔴 **قرمز**: خطا یا در حال پردازش
- 🟡 **زرد**: پردازش در حال انجام
- 🟢 **سبز**: عملیات موفق
- 🔵 **آبی**: آماده

### 📋 ListBox - لیست (listBox1)
**موقعیت**: تب‌های 2 و 3
**عملکرد**: نمایش نتایج جستجو و فایل‌ها
**ویژگی‌ها**:
- **DoubleClick**: باز کردن فایل در Notepad++
- نمایش نتایج جستجوی متن
- نمایش لیست DTCها
- انتخاب فایل برای باز کردن

## 🔘 دکمه‌های اصلی

### تب اصلی

#### 1. `cleartemp` - پاک کردن فایل‌های موقت
```csharp
private void cleartemp_Click(object sender, EventArgs e)
{
    resultlabel.Text = "Please Wait Clear Temp ...";
    resultlabel.BackColor = Color.Red;
    f.cleartemp();  // پاک کردن temp
    f.clearout();   // پاک کردن output
}
```

#### 2. `ChangeDics` - تغییر دیکشنری
```csharp
private void ChangeDics_Click_Click(object sender, EventArgs e)
{
    resultlabel.Text = "Please Wait Change Dictionary ...";
    resultlabel.BackColor = Color.Red;
    f.changedics();
}
```

#### 3. `convertbutton` - تبدیل فرمت
```csharp
private void convertbutton_Click(object sender, EventArgs e)
{
    if (converttextBox.Text == string.Empty)
    {
        resultlabel.Text = "Input Data Invalid";
        resultlabel.BackColor = Color.Red;
    }
    else
        f.converthexasciibin(); // تبدیل hex ↔ ascii ↔ binary
}
```

#### 4. `convertclear` - پاک کردن TextBox
```csharp
private void convertclear_Click(object sender, EventArgs e)
{
    converttextBox.Clear();
    resultlabel.Text = "Clear Convert Textbox";
    resultlabel.BackColor = Color.GreenYellow;
}
```

#### 5. `obdconnector` - نمایش کانکتور OBD
```csharp
private void obdconnector_Click(object sender, EventArgs e)
{
    converttextBox.Text = f.obdconnector();
}
```

#### 6. `ecuid` - پشتیبانی ECU ID
```csharp
private void ecuid_Click(object sender, EventArgs e)
{
    converttextBox.Text = f.ecuidsupport();
}
```

#### 7. `initpinbtn` - نمایش پین‌های Initial
```csharp
private void initpinbtn_Click(object sender, EventArgs e)
{
    converttextBox.Text = f.initialpin();
}
```

#### 8. `buttonsctosim` - اسکریپت به شبیه‌ساز
```csharp
private void buttonsctosim_Click(object sender, EventArgs e)
{
    // پردازش فایل‌های .jc
}
```

### تب‌های پیشرفته (2 و 3)

#### 9. `btnloadfile` - بارگذاری فایل
```csharp
private void btnloadfile_Click(object sender, EventArgs e)
{
    // باز کردن دیالوگ انتخاب فایل
    // پشتیبانی از: .txt, .log, .csv, .c, .h, .json
}
```

#### 10. `btnsetfilter` - تنظیم فیلتر
```csharp
private void btnsetfilter_Click(object sender, EventArgs e)
{
    // اضافه کردن کلمه کلیدی به لیست فیلتر
}
```

#### 11. `btnremovefilter` - حذف فیلتر
```csharp
private void btnremovefilter_Click(object sender, EventArgs e)
{
    // حذف آیتم انتخاب شده از لیست فیلتر
}
```

#### 12. `btnlimitshow` - نمایش محدود
```csharp
private void btnlimitshow_Click(object sender, EventArgs e)
{
    // نمایش تعداد محدودی از نتایج
}
```

#### 13. `btnclearallfilter` - پاک کردن همه فیلترها
```csharp
private void btnclearallfilter_Click(object sender, EventArgs e)
{
    // پاک کردن تمام فیلترها
}
```

#### 14. `btnfinddtc` - جستجوی DTC
```csharp
private void btnfinddtc_Click(object sender, EventArgs e)
{
    // جستجوی کدهای خطا (DTC)
}
```

#### 15. `btnalldtc` - همه DTCها
```csharp
private void btnalldtc_Click(object sender, EventArgs e)
{
    // استخراج تمام کدهای خطا
}
```

#### 16. `btnFolderPath` - انتخاب پوشه
```csharp
private void btnFolderPath_Click(object sender, EventArgs e)
{
    // انتخاب مسیر پوشه
}
```

### تب‌های دیگر

#### 17. `frmlen` - محاسبه طول فریم
```csharp
private void frmlen_Click(object sender, EventArgs e)
{
    f.frm_len(converttextBox.Text);
}
```

#### 18. `logtoout` - لاگ به خروجی
```csharp
private void logtoout_Click(object sender, EventArgs e)
{
    // تبدیل فایل‌های لاگ
}
```

#### 19. `getdanacode` - دریافت کد داده
```csharp
private void getdanacode_Click(object sender, EventArgs e)
{
    // دریافت کدهای داده
}
```

## 📁 عملکردهای فایل

### پردازش فایل‌های .jc
1. **انتخاب فایل**: `buttonsctosim` یا drag & drop
2. **تشخیص پروتکل**: KWP، CAN، یا سایر پروتکل‌ها
3. **پردازش initial**: استخراج و تبدیل initialها
4. **تولید فایل‌ها**:
   - `.frm`: فایل فریم برای نمایش
   - `.sim`: فایل شبیه‌ساز برای استفاده

### جستجوی فایل‌ها
1. **بارگذاری**: `btnloadfile`
2. **فیلتر**: `btnsetfilter`
3. **جستجو**: در فایل‌های متنی
4. **نمایش**: نتایج در `listBox1`
5. **باز کردن**: DoubleClick روی آیتم

## 🎨 ویژگی‌های رابط کاربری

### تغییر اندازه خودکار
- **تب‌های 0،1**: اندازه 600x400
- **تب‌های 2،3**: اندازه 900x600
- `resultlabel` در تب‌های بزرگ مخفی می‌شود

### بازخورد بصری
- **رنگ‌های وضعیت**: 🔴🟡🟢🔵
- **پیام‌های خطا**: MessageBox با آیکون مناسب
- **تایید عملیات**: رنگ سبز برای موفقیت

### دسترسی سریع
- **DoubleClick**: باز کردن فایل‌ها
- **Drag & Drop**: کشیدن فایل‌ها
- **Keyboard**: دسترسی از طریق کلیدها

## ⚙ تنظیمات و پیکربندی

### مسیرها
- `globalPath`: مسیر فایل فعلی
- `globalFolderPath`: مسیر پوشه انتخاب شده
- `selectedFilePath`: فایل انتخاب شده

### متغیرها
- `filePathsArray`: آرایه مسیر فایل‌ها
- `addedItems`: آیتم‌های اضافه شده (HashSet)
- `currentCANInfo`: اطلاعات CAN فعلی

## 🔍 عملکردهای پیشرفته

### پردازش پروتکل‌ها
- **KWP**: 3 مدل مختلف
- **CAN**: 11-bit و 29-bit
- **تشخیص خودکار**: بر اساس ساختار داده

### مدیریت حافظه
- `cleartemp`: پاک کردن فایل‌های موقت
- `clearout`: پاک کردن خروجی‌ها

### جستجو و فیلتر
- **متن**: جستجوی کلمه کلیدی
- **DTC**: جستجوی کدهای خطا
- **فایل**: فیلتر فایل‌ها

## 📊 آمار و اطلاعات

### کنترل‌ها
- **TextBox**: 1 عدد (converttextBox)
- **Label**: 1 عدد (resultlabel)
- **ListBox**: 1 عدد (listBox1)
- **Button**: 19 عدد (دکمه‌های مختلف)
- **TabControl**: 1 عدد (با چندین تب)

### عملکردها
- **Event Handler**: 22 عدد
- **تب**: حداقل 4 عدد
- **پروتکل**: 2 نوع اصلی (KWP، CAN)
- **مدل**: 5 مدل مختلف (3 KWP + 2 CAN)

## 🚨 نکات مهم

### استفاده صحیح
- همیشه مسیر فایل‌ها را بررسی کنید
- از فرمت‌های پشتیبانی شده استفاده کنید
- پیام‌های خطا را مطالعه کنید
- قبل از پردازش، فایل‌های ورودی را backup بگیرید

### عیب‌یابی
- **خطای باز کردن فایل**: مسیر فایل را بررسی کنید
- **خطای پردازش**: فرمت فایل ورودی را بررسی کنید
- **خطای جستجو**: کلمه کلیدی را بررسی کنید
- **خطای تبدیل**: داده‌های ورودی را بررسی کنید

---

**Mehad Tools** - نرم‌افزار حرفه‌ای با رابط کاربری کاربرپسند برای پردازش فایل‌های تشخیصی خودرو 🚗🔧

## 🚀 ویژگی‌های اصلی

### 📁 پردازش فایل‌های ورودی
- **پشتیبانی از فرمت .jc**: پردازش فایل‌های اسکریپت تشخیصی
- **تشخیص خودکار پروتکل**: KWP، CAN و سایر پروتکل‌ها
- **پردازش دسته‌ای**: امکان پردازش چندین فایل به طور همزمان

### 🔧 پردازش پروتکل‌ها

#### KWP (Keyword Protocol 2000)
- **تشخیص خودکار مدل**: 3 مدل مختلف KWP
  - **مدل 1**: `(0x80+Length) + target + source + SID + data + checksum`
  - **مدل 2**: `(0x80) + target + source + Length + SID + data + checksum`
  - **مدل 3**: `Length + SID + data + checksum`

#### CAN (Controller Area Network)
- **تشخیص خودکار نوع**: 11-bit و 29-bit
- **پردازش CAN ID**: استخراج و پردازش صحیح CAN IDها
- **پشتیبانی از GOTO frames**: پردازش فریم‌های "GOTO CAN MODE"

### 📤 فایل‌های خروجی

#### فایل .frm (Frame)
- شامل تمام فریم‌های شناسایی شده
- فرمت مناسب برای نمایش و تحلیل

#### فایل .sim (Simulation)
- فایل شبیه‌ساز برای استفاده در دستگاه‌های تشخیصی
- شامل initial مناسب برای هر پروتکل
- ساختار استاندارد برای شبیه‌سازها

## 🛠 نحوه استفاده

### 1. آماده‌سازی فایل‌ها
1. فایل‌های .jc خود را در پوشه مورد نظر قرار دهید
2. نرم‌افزار Mehad Tools را اجرا کنید
3. فایل‌های ورودی را انتخاب کنید

### 2. پردازش فایل‌ها
1. روی دکمه "Convert" کلیک کنید
2. نرم‌افزار به طور خودکار:
   - پروتکل‌ها را تشخیص می‌دهد
   - مدل‌های مناسب را انتخاب می‌کند
   - فایل‌های .frm و .sim را تولید می‌کند

### 3. بررسی نتایج
- فایل‌های خروجی در همان پوشه فایل‌های ورودی ایجاد می‌شوند
- فایل .frm برای تحلیل فریم‌ها
- فایل .sim برای استفاده در شبیه‌سازها

## 📊 ساختار پروتکل‌ها

### KWP مدل 1
```
Request:  (0x80+Length) + target + source + SID + data + checksum
Response: (0x80+Length) + source + target + (SID+0x40) + data + checksum
```

### KWP مدل 2
```
Request:  (0x80) + target + source + Length + SID + data + checksum
Response: (0x80) + source + target + Length + (SID+0x40) + data + checksum
```

### KWP مدل 3
```
Request:  Length + SID + data + checksum
Response: Length + (SID+0x40) + data + checksum
```

### CAN 11-bit
```
CAN_ID (2 bytes) + SID + Data
```

### CAN 29-bit
```
CAN_ID (4 bytes) + SID + Data
```

## ⚙ تنظیمات پیشرفته

### تشخیص CAN ID
- نرم‌افزار به طور خودکار 4 بایت CAN ID را می‌خواند
- اگر مقدار < 0x07FF باشد → CAN 11-bit
- در غیر این صورت → CAN 29-bit

### Initial مناسب
- **CAN 11-bit**: `I={6,1,500000,0,0}`
- **CAN 29-bit**: `I={7,1,250000,0,0}`

### پردازش SID
- برای SIDهای خاص (0x27, 0x30, 0x31, 0x3B, 0x2E, 0x2F, 0x34, 0x36):
  - خط `X={4};` به پاسخ اضافه می‌شود

## 🔍 عیب‌یابی

### مشکلات رایج

#### 1. خطای تشخیص پروتکل
**علت**: ساختار فایل .jc نامناسب
**راه‌حل**: بررسی فرمت و ساختار فایل ورودی

#### 2. خطای تبدیل CAN ID
**علت**: CAN ID نامعتبر یا فرمت نادرست
**راه‌حل**: بررسی 4 بایت CAN ID در فایل ورودی

#### 3. خطای تولید پاسخ
**علت**: SID نامعتبر یا داده‌های ناکافی
**راه‌حل**: بررسی داده‌های SID و پارامترهای درخواست

## 📝 مثال‌های عملی

### مثال 1: KWP مدل 1
```
ورودی: {81,17,F1,3E,C7}
خروجی C: {17,F1,81,3E,C7}
خروجی R: {82,F1,17,7E,7E,65}
```

### مثال 2: KWP مدل 3
```
ورودی: {05,22,11,1C,04,01,59}
خروجی C: {22,11,1C,04,01}
خروجی R: {05,62,11,1C,04,01,45,30,45,XX}
```

### مثال 3: CAN 11-bit
```
CAN ID: 0x000007FE (2046)
→ تشخیص: CAN 11-bit
→ Initial: I={6,1,500000,0,0}
```

## 🆘 پشتیبانی

در صورت بروز مشکل:

1. **بررسی فایل‌های ورودی**: فرمت و ساختار فایل‌ها
2. **بررسی تنظیمات**: پارامترهای نرم‌افزار
3. **بررسی خروجی‌ها**: فایل‌های .frm و .sim تولید شده
4. **لاگ خطاها**: پیام‌های خطای نرم‌افزار

## 📈 نکات مهم

- ✅ همیشه از فایل‌های .jc معتبر استفاده کنید
- ✅ ساختار پروتکل‌ها را رعایت کنید
- ✅ CAN IDها را به درستی تنظیم کنید
- ✅ از مدل‌های صحیح KWP استفاده کنید
- ✅ فایل‌های خروجی را بررسی کنید

## 🔄 به‌روزرسانی‌ها

### نسخه فعلی
- پشتیبانی کامل از 3 مدل KWP
- تشخیص خودکار CAN 11-bit و 29-bit
- پردازش پیشرفته initialها
- تولید فایل‌های استاندارد .frm و .sim

---

**Mehad Tools** - نرم‌افزار حرفه‌ای پردازش فایل‌های تشخیصی خودرو 🚗🔧
