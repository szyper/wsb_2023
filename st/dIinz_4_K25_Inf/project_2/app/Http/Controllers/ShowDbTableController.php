<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use Illuminate\Support\Facades\DB;

class ShowDbTableController extends Controller
{
    public function ShowUsers(){
      $users = DB::table('users')->select('name', 'email', 'created_at')->get();
//      print_r($users);
      return view('userstable', ['users' => $users]);
    }
}
