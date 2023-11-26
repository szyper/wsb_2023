<?php

namespace App\Http\Controllers;
use App\Models\User;

use Illuminate\Http\Request;

class ShowUserController extends Controller
{
    public function ShowUser(){
      //return User::all();

      $users = User::all();

      return view('users.show_users', ['users' => $users]);
    }
}
