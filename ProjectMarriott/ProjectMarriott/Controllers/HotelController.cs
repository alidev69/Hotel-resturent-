using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectMarriott.HelperMethods;
using ProjectMarriott.Models.HotelViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectMarriott.Controllers
{
    public class HotelController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Gallery()
        {
            return View();
        }


        [Authorize]
        public IActionResult Reservation()
        {
            return View("Reservation");
        }

        [HttpPost]
        [Authorize]
        public IActionResult Reservation(ReservationModel reservationModel)
        {
            return View("Reservation", reservationModel);
        }

        [Authorize]
        [HttpPost]
        public IActionResult SaveBookingDates(ReservationModel reservationModel)
        {
            return View("Reservation", reservationModel);
        }

        [Authorize]
        [HttpPost]
        public IActionResult SaveRoomDetails(ReservationModel reservationModel)
        {
            if (ModelState.IsValid)
            {
                reservationModel.RoomDetails = new List<RoomModel>();
                reservationModel.CustomerDetails = new CustomerModel();
                reservationModel.CustomerDetails.Address = new AddressModel();
                if (reservationModel.IsSingleRoom == true)
                {
                    var roomModel = new RoomModel(RoomType.SingleRoom.ToString(), (double)RoomTariff.SingleRoom,
                        true, (int)RoomsAvailable.SingleRoom);
                    reservationModel.RoomDetails.Add(roomModel);
                }
                if (reservationModel.IsDoubleRoom == true)
                {
                    var roomModel = new RoomModel(RoomType.DoubleRoom.ToString(), (double)RoomTariff.DoubleRoom,
                        true, (int)RoomsAvailable.DoubleRoom);
                    reservationModel.RoomDetails.Add(roomModel);
                }
                if (reservationModel.IsDeluxeOneBedroom == true)
                {
                    var roomModel = new RoomModel(RoomType.DeluxeOneBedroomSuite.ToString(),
                        (double)RoomTariff.DeluxeOneBedroomSuite,
                        true, (int)RoomsAvailable.DeluxeOneBedroomSuite);
                    reservationModel.RoomDetails.Add(roomModel);
                }
                if (reservationModel.IsDeluxeTwoBedroom == true)
                {
                    var roomModel = new RoomModel(RoomType.DeluxeTwoBedroomSuite.ToString(),
                        (double)RoomTariff.DeluxeTwoBedroomSuite,
                        true, (int)RoomsAvailable.DeluxeTwoBedroomSuite);
                    reservationModel.RoomDetails.Add(roomModel);
                }
                if (reservationModel.IsRoyalSuit == true)
                {
                    var roomModel = new RoomModel(RoomType.RoyalSuit.ToString(), (double)RoomTariff.RoyalSuit,
                        true, (int)RoomsAvailable.RoyalSuit);
                    reservationModel.RoomDetails.Add(roomModel);
                }
                if (reservationModel.IsKingSuit == true)
                {
                    var roomModel = new RoomModel(RoomType.KingSuit.ToString(), (double)RoomTariff.KingSuit,
                        true, (int)RoomsAvailable.KingSuit);
                    reservationModel.RoomDetails.Add(roomModel);
                }

                if (reservationModel != null && reservationModel.RoomDetails != null &&
                reservationModel.RoomDetails.Count > 0)
                {
                    double totalCostofBooking = 0.0;

                    foreach (var room in reservationModel.RoomDetails)
                    {
                        totalCostofBooking += (double)room.RoomTariff;
                    }

                    reservationModel.TotalCost = totalCostofBooking;
                }

            }

            return View("Reservation", reservationModel);
        }

        [Authorize]
        [HttpPost]
        public IActionResult SubmitCustomerData(ReservationModel reservationModel)
        {
            if (ModelState.IsValid)
            {
                //Generate a booking ID 
                reservationModel.BookingID = HelperMethods.HelperMethods.RandomString(10);
                reservationModel.BookingDate = DateTime.Today;
            }

            HttpContext.Session.SetObjectAsJson("ReservationModel", reservationModel);
            return View("Reservation", reservationModel);
        }

        //[Authorize]
        //[HttpPost]
        //public IActionResult SaveBookingDates(ReservationModel reservationModel)
        //{
        //    return View("Reservation", reservationModel);
        //}

        //[Authorize]
        //[HttpPost]
        //public IActionResult SaveRoomDetails(ReservationModel reservationModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        reservationModel.RoomDetails = new List<RoomModel>();
        //        reservationModel.CustomerDetails = new CustomerModel();
        //        reservationModel.CustomerDetails.Address = new AddressModel();
        //        if (reservationModel.IsSingleRoom == true)
        //        {
        //            var roomModel = new RoomModel(RoomType.SingleRoom, (double)RoomTariff.SingleRoom,
        //                true, (int)RoomsAvailable.SingleRoom);
        //            reservationModel.RoomDetails.Add(roomModel);
        //        }
        //        if (reservationModel.IsDoubleRoom == true)
        //        {
        //            var roomModel = new RoomModel(RoomType.DoubleRoom, (double)RoomTariff.DoubleRoom,
        //                true, (int)RoomsAvailable.DoubleRoom);
        //            reservationModel.RoomDetails.Add(roomModel);
        //        }
        //        if (reservationModel.IsDeluxeOneBedroom == true)
        //        {
        //            var roomModel = new RoomModel(RoomType.DeluxeOneBedroomSuite, 
        //                (double)RoomTariff.DeluxeOneBedroomSuite,
        //                true, (int)RoomsAvailable.DeluxeOneBedroomSuite);
        //            reservationModel.RoomDetails.Add(roomModel);
        //        }
        //        if (reservationModel.IsDeluxeTwoBedroom == true)
        //        {
        //            var roomModel = new RoomModel(RoomType.DeluxeTwoBedroomSuite, 
        //                (double)RoomTariff.DeluxeTwoBedroomSuite,
        //                true, (int)RoomsAvailable.DeluxeTwoBedroomSuite);
        //            reservationModel.RoomDetails.Add(roomModel);
        //        }
        //        if (reservationModel.IsRoyalSuit == true)
        //        {
        //            var roomModel = new RoomModel(RoomType.RoyalSuit, (double)RoomTariff.RoyalSuit,
        //                true, (int)RoomsAvailable.RoyalSuit);
        //            reservationModel.RoomDetails.Add(roomModel);
        //        }
        //        if (reservationModel.IsKingSuit == true)
        //        {
        //            var roomModel = new RoomModel(RoomType.KingSuit, (double)RoomTariff.KingSuit,
        //                true, (int)RoomsAvailable.KingSuit);
        //            reservationModel.RoomDetails.Add(roomModel);
        //        }

        //        if (reservationModel != null && reservationModel.RoomDetails != null &&
        //        reservationModel.RoomDetails.Count > 0)
        //        {
        //            double totalCostofBooking = 0.0;

        //            foreach (var room in reservationModel.RoomDetails)
        //            {
        //                totalCostofBooking += (double)room.RoomTariff;
        //            }

        //            reservationModel.TotalCost = totalCostofBooking;
        //        }

        //    }

        //    return View("Reservation", reservationModel);
        //}

        //[Authorize]
        //[HttpPost]
        //public IActionResult SubmitCustomerData(ReservationModel reservationModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        //Generate a booking ID 
        //        reservationModel.BookingID = HelperMethods.HelperMethods.RandomString(10);
        //    }

        //    HttpContext.Session.SetObjectAsJson("ReservationModel", reservationModel);
        //    return View("Reservation", reservationModel);
        //}

        [Authorize]
        [HttpGet]
        public IActionResult CustomerHistory()
        {
            var reservationModel = HttpContext.Session.GetObjectFromJson<ReservationModel>("ReservationModel");

            return View("CustomerHistory", reservationModel);
        }

        public IActionResult Rooms()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }
    }
}
