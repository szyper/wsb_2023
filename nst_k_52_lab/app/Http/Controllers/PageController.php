<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;

class PageController extends Controller
{
    public function show(){
      return 'Kontroler PageController';
    }

    public function showDrives($drive){
      /*$drives = [
        'fdd' => 'dyskietka',
        'hdd' => 'dysk HDD',
        'ssd' => 'dysk SSD',
      ];*/

      $drives = match($drive) {
        'fdd' => 'dyskietka',
        'hdd' => 'dysk HDD',
        'ssd' => 'dysk SSD',
        default => 'Błędne dane podane przez użytkownika'
      };

      //return $drives[$drive];
      return $drives;
    }
}
