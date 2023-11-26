<?php

namespace Database\Seeders;

use Illuminate\Database\Console\Seeds\WithoutModelEvents;
use Illuminate\Database\Seeder;
use Faker\Factory;
use Illuminate\Support\Facades\DB;

class BooksSeeder extends Seeder
{
    /**
     * Run the database seeds.
     */
    public function run(): void
    {
        $faker = Factory::create('pl_PL');

        for ($i = 0; $i < 50; $i++){
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
