import { Routes } from '@angular/router';
import { Home } from './components/home/home';
import { Login } from './components/login/login';
import { Register } from './components/register/register';
import { Rooms } from './components/rooms/rooms';
import { BookRoom } from './components/book-room/book-room';
import { MyBookings } from './components/my-bookings/my-bookings';
import { Profile } from './components/profile/profile';
import { OwnerRegister } from './components/owner-register/owner-register';
import { AvailableRooms } from './components/available-rooms/available-rooms';
import { TaskStatus } from './components/task-status/task-status';
import { OwnerDashboard } from './components/owner-dashboard/owner-dashboard';
import { ManagerDashboard } from './components/manager-dashboard/manager-dashboard';
import { ReceptionistDashboard } from './components/receptionist-dashboard/receptionist-dashboard';
import { CreateManager } from './components/create-manager/create-manager';
import { CreateReceptionist } from './components/create-receptionist/create-receptionist';
import { CreateStaff } from './components/create-staff/create-staff';
import { StaffDashboard } from './components/staff-dashboard/staff-dashboard';
import { RoomTypes } from './components/room-types/room-types';
import { RoomsManagement } from './components/rooms-management/rooms-management';
import { PendingBookings } from './components/pending-bookings/pending-bookings';
import { BookingHistory } from './components/booking-history/booking-history';
import { BookingOverview } from './components/booking-overview/booking-overview';
import { AssignTask } from './components/assign-task/assign-task';
import { MyTasks } from './components/my-tasks/my-tasks';
import { CompletedTasks } from './components/completed-tasks/completed-tasks';
import { OwnerRoomDetails } from './components/owner-room-details/owner-room-details';
import { OccupiedRooms } from './components/occupied-rooms/occupied-rooms';
import { MaintenanceRooms } from './components/maintenance-rooms/maintenance-rooms';
import { UserDetails } from './components/user-details/user-details';
import { TotalBookings } from './components/total-bookings/total-bookings';
import { OwnerRejectedBookings } from './components/owner-rejected-bookings/owner-rejected-bookings';
import { OwnerPendingBookings } from './components/owner-pending-bookings/owner-pending-bookings';
import { OwnerAcceptedBookings } from './components/owner-accepted-bookings/owner-accepted-bookings';


export const routes: Routes = [

    { path: '', component: Home },

  { path: 'login', component: Login },

  { path: 'register', component: Register },

  { path: 'rooms', component: Rooms },

  { path: 'book-room/:id', component: BookRoom },

  { path: 'my-bookings', component: MyBookings },

  { path: 'profile', component: Profile },

  { path: 'owner-dashboard', component: OwnerDashboard },

  { path: 'manager-dashboard', component: ManagerDashboard },

  { path: 'receptionist-dashboard', component: ReceptionistDashboard },

  {
    path: 'owner-register', component: OwnerRegister },

{
    path: 'create-manager',component: CreateManager },

{
    path: 'create-receptionist',component: CreateReceptionist },

{
    path: 'create-staff',component: CreateStaff },

{
    path: 'staff-dashboard',component: StaffDashboard },

{
    path: 'room-types',component: RoomTypes },

{
    path: 'rooms-management',component: RoomsManagement },

{
  path: 'pending-bookings',component: PendingBookings },

{
    path:'booking-history', component:BookingHistory },

{
    path: 'booking-overview', component: BookingOverview },

{
    path:'assign-task', component:AssignTask },
{
  path: 'my-tasks', component: MyTasks },
{
  path: 'completed-tasks', component: CompletedTasks },

{
    path:'owner-room-details', component:OwnerRoomDetails },

{
    path:'available-rooms', component:AvailableRooms },

{
  path: 'occupied-rooms', component: OccupiedRooms },

{
    path: 'maintenance-rooms', component: MaintenanceRooms},

{
    path: 'user-details/:role', component: UserDetails },

{
  path:'total-bookings', component:TotalBookings },

{ path: 'owner-pending-bookings', component: OwnerPendingBookings },

{ path: 'owner-accepted-bookings', component: OwnerAcceptedBookings },

{ path: 'owner-rejected-bookings', component: OwnerRejectedBookings },

{ path: 'task-status',component: TaskStatus },

  { path: '**', redirectTo: '' }
];
