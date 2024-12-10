using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Hotel_Reservation.Application.Features.Guests.Commands.CreateGuest;
using Hotel_Reservation.Application.Features.Guests.Commands.UpdateGuest;
using Hotel_Reservation.Application.Features.Reservation.Commands.CreateReservation;
using Hotel_Reservation.Application.Features.Reservation.Commands.UpdateReservation;
using Hotel_Reservation.Application.Features.Reviews.Command.AddReview;
using Hotel_Reservation.Application.Features.Reviews.Queries.GetReviewRooms;
using Hotel_Reservation.Application.Features.Rooms.Commands.CreateRoom;
using Hotel_Reservation.Application.Features.Rooms.Commands.UpdateRoom;
using Hotel_Reservation.Core.Entities;
using Hotel_Reservation.Core.Models;

namespace Hotel_Reservation.Application.Common.Mapping
{
    public class ProfileMapping : Profile
    {
        public ProfileMapping()
        {
            CreateMap<Room, RoomDto>().ReverseMap();
            CreateMap<CreateRoomCommand, Room>().ReverseMap();
            CreateMap<UpdateRoomCommand, Room>().ReverseMap();
            // Review Mapping
            CreateMap<Review, ReviewDto>().ReverseMap();
            CreateMap<AddReviewCommand, ReviewCreateDto>().ReverseMap();
            CreateMap<GetRoomReviewQuery, ReviewDto>().ReverseMap();
            CreateMap<RoomReview, ReviewDto>().ReverseMap();
            CreateMap<Review, RoomReview>().ReverseMap();
            // Guest Mapping
            CreateMap<Guest, GuestDto>().ReverseMap();
            CreateMap<Guest, UpdateGuestCommand>().ReverseMap();
            CreateMap<Guest, CreateGuestCommand>().ReverseMap();
            // Reserve Mapping
            CreateMap<Reserve, CreateReservationCommand>().ReverseMap();
            CreateMap<Reserve, UpdateReservationCommand>().ReverseMap();
            CreateMap<Reserve, ReservationDto>().ReverseMap();


        }
    }
}
