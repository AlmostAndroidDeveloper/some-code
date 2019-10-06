#include "pch.h"
#include <iostream>
#include <fstream>
#include <string>
using namespace std;

#define PATH "C:\\Users\\AlmostDeveloper\\Desktop\\INPUT.txt"
#define OUT_PATH "C:\\Users\\AlmostDeveloper\\Desktop\\OUTPUT.txt"
#define MAX_LINES 1024

int counter = 0;
string lines_array[MAX_LINES];

void make_output_file() {
	ofstream write_file(OUT_PATH);
	for (int i = 4;i >= 0;i--)
	{
		if (counter < 4)
		{
			cout << "Количество строк в файле меньше 3";
			break;
		}
		cout << lines_array[counter - i] << endl;
		write_file << lines_array[counter - i] << endl;
	}
	write_file.close();
}

void fill_lines_array_from_file() {
	string line;
	ifstream read_file(PATH);
	if (read_file.is_open())
	{
		while (!read_file.eof())
		{
			getline(read_file, line);
			lines_array[counter] = line;
			counter++;
		}
		read_file.close();
	}
}

int main()
{
	setlocale(LC_ALL, "RUSSIAN");
	fill_lines_array_from_file();
	make_output_file();
}