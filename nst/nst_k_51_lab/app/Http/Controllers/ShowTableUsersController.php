<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use Illuminate\Support\Facades\DB;
use Illuminate\View\View;
class ShowTableUsersController extends Controller
{
    public function show(){
      //return DB::select('select * from users');
      //return DB::table('users')->get();

      return DB::table('users')
        ->where('firstName', 'Janusz')
        ->get();
    }

    public function index(): View
    {
      $users = DB::select('select * from users where firstName = ?', ['Janusz']);
      return view('users.showusers', ['users' => $users]);
    }
}
