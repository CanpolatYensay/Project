let randevular = [];

const form = document.querySelector("form");
const adInput = document.querySelector('input[type="text"]');
const telInput = document.querySelector('input[type="tel"]');
const tarihInput = document.querySelector('input[type="date"]');
const saatSelect = document.querySelector("select");
const uyari = document.querySelector(".uyarı");



db.collection("randevular").get().then(snapshot => {
    snapshot.forEach(doc => {
        randevular.push(doc.data());
    });
});



form.addEventListener("submit", function (e) {
    e.preventDefault();

    const adSoyad = adInput.value;
    const telefon = telInput.value;
    const tarih = tarihInput.value;
    const saat = saatSelect.value;
    const secilenTarih = new Date(tarih);

    

    // PERŞEMBE KONTROLÜ
    if (secilenTarih.getDay() === 4) {
        uyari.style.color = "red";
        uyari.textContent = "Perşembe günleri kapalıyız. Lütfen başka bir gün seçin.";
        return;
    }

    // ÇAKIŞMA KONTROLÜ
    const cakismaVarMi = randevular.some(r =>
        r.tarih === tarih && r.saat === saat
    );

    if (cakismaVarMi) {
        uyari.style.color = "red";
        uyari.textContent = "Bu tarih ve saatte başka bir randevu bulunmaktadır.";
        return;
    }

    db.collection("randevular").add({
        adSoyad,
        telefon,
        tarih,
        saat,
        olusturmaZamani: firebase.firestore.FieldValue.serverTimestamp()
    });

    randevular.push({ adSoyad, telefon, tarih, saat });

    uyari.style.color = "green";
    uyari.textContent = "Randevunuz başarıyla oluşturuldu ✅";

    form.reset();
});
