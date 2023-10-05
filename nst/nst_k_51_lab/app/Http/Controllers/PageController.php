<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;

class PageController extends Controller
{
    public function show($drive){
        /*
        $drives = [
            'fdd' => 'Dyskietka',
            'hdd' => 'Dysk HDD',
            'ssd' => 'Dysk SSD',
        ];
        */

        //return $drives[$drive];

        //$show = array_key_exists($drive, $drives) ? $drives[$drive] : 'Błędne dane';
        //return $show;

        $drives =match(strtolower($drive)) {
            'fdd' => 'Dyskietka',
            'hdd' => 'Dysk HDD',
            'ssd' => 'Dysk SSD',
            default => 'Błędna wartość podana przez użytkownika'
        };
        return $drives;
    }
}
