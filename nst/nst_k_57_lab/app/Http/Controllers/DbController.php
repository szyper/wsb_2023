<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use Illuminate\Support\Facades\DB;
use Illuminate\View\View;
use function Laravel\Prompts\select;

class DbController extends Controller
{
  public function show(){
    //return DB::select('select name, password from users');
    //return DB::table('users')->select('name')->get();

    /*
    return DB::table('users')
      ->select('name', 'password')
      ->where('name', 'jan')
      ->get();
    */

    /*
    DB::table('user')
      ->insert(
        [
          'firstName' => 'Krystyna',
          'lastName' => 'Nowak',
          'birthday' => '2000-03-10',
        ]
      );
    */

    /*DB::table('user')
      ->where('lastname', 'nowak')
      ->update(
        [
          'lastname' => 'Kowal'
        ]
      );*/

    /*DB::table('user')
      ->where('lastname', 'kowal')
      ->update(
        [
          'lastname' => 'kowalnowy',
          'firstname' => 'noweimie',
        ]
      );*/

    //return DB::table('user')->avg('height');
    return number_format(DB::table('user')->avg('height'), 2)."cm";
  }

  public function showUser() : View
  {
    //$user = ['name' => 'Jan'];
    $user = DB::select('select * from users where name = ?', ['Jan']);
    return view('db.show_user', ['user' => $user]);
  }
}
