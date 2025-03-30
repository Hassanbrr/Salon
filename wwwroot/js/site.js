function rtl() {
    var body = document.body;
    body.classList.toggle("rtl");
}

function dark() {
    var body = document.body;
    body.classList.toggle("dark");
}




// Modal
$('#deleteModal').on('show.bs.modal', function (event) {
    const button = $(event.relatedTarget); // دکمه‌ای که مدال را فعال کرده
    const serviceId = button.attr('asp-route-id'); // دریافت ID از دکمه
    const serviceName = button.data('name'); // دریافت نام خدمات

    // نمایش نام خدمات در مدال
    $('#serviceName').text(serviceName);

    // تنظیم لینک حذف در مدال با ID
    $('#confirmDelete').attr('href', `/Services/Delete/${serviceId}`);
});
console.log(typeof bootstrap);


//$(document).ready(function () {
//    $('#servicesTable').DataTable({
//        responsive: true, // فعال کردن ریسپانسیو
 

//        pageLength: 5, // تعداد رکوردها در هر صفحه

//        language: {
//            search: "جستجو:",
//            lengthMenu: "نمایش _MENU_ رکورد در هر صفحه",

//            zeroRecords: "هیچ رکوردی پیدا نشد",
//            info: "نمایش _PAGE_ از _PAGES_",
//            infoEmpty: "رکوردی موجود نیست",
//            paginate: {
//                first: "اولین",
//                last: "آخرین",
//                next: "بعدی",
//                previous: "قبلی"
//            }
//        },

//    });
    //$('#servicesTable').DataTable({
    //    ajax: '/api/services', // آدرس API
    //    columns: [
    //        { data: 'ServiceId' },
    //        { data: 'ServiceName' },
    //        { data: 'description' },
    //        { data: 'Price' },
    //        { data: 'Duration' },
    //        { data: 'slug' }
    //        ,
    //    ]
    //});

});