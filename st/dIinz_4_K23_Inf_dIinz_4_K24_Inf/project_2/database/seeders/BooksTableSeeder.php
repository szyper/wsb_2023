<?php

namespace Database\Seeders;

use Illuminate\Database\Console\Seeds\WithoutModelEvents;
use Illuminate\Database\Seeder;
//use Faker\Factory as Faker;
use Faker\Factory;
use Illuminate\Support\Facades\DB;

class BooksTableSeeder extends Seeder
{
    /**
     * Run the database seeds.
     */
    public function run(): void
    {
        $faker = Factory::create();

        for ($i = 0; $i < 10; $i++){
          $data = [
            'title' => $faker->sentence(3),
            'author' => $faker->name,
            'genre' => $faker->randomElement(['fantasy', 'horror', 'romance']),
            'year' => $faker->year,
            'created_at' => now(),
            'updated_at' => now()
          ];
          DB::table('books')->insert($data);
        }
    }
}
