#define use_CRT_SECURE_NO_WARNINGS
#include "pch.h"
#include <iostream>
#include <fstream>
#include <string>

#define PATH "C:\\Users\\AlmostDeveloper\\Desktop\\INPUT.txt"
#define OUT_PATH "C:\\Users\\AlmostDeveloper\\Desktop\\OUTPUT.txt"
#define MAX_LINES 1024
#define OPERATORS "+-*/"
#define NUMBERS "1234567890"

#pragma warning(disable : 4996)
using namespace std;

string input;
char num_str[1024];
char op_str[1024];
int num_array[1024];
char op_array[1024];
int op_array_count = 0;

void write_result_into_file(int result) {
	ofstream write_file(OUT_PATH);
	write_file << result << endl;
	write_file.close();
}

int calculate_all() {
	int res = num_array[0];
	for (int i = 0;i < op_array_count;i++) {
		switch (op_array[i])
		{
		case '+':
			res += num_array[i + 1];
			break;
		case '-':
			res -= num_array[i + 1];
			break;
		case '*':
			res *= num_array[i + 1];
			break;
		case '/':
			res /= num_array[i + 1];
			break;
		default:
			break;
		}
	}
	return res;
}

void fill_operators_array() {
	char * ops = strtok(op_str, NUMBERS);
	while (ops != NULL)
	{
		op_array[op_array_count] = *ops;
		ops = strtok(NULL, NUMBERS);
		op_array_count++;
	}
}

void fill_numbers_array() {
	int num_array_count = 0;
	char *numbers = strtok(num_str, OPERATORS);
	while (numbers != NULL)
	{
		num_array[num_array_count] = (int)(*numbers - '0');
		numbers = strtok(NULL, OPERATORS);
		num_array_count++;
	}
}

void make_op_and_num_strings() {
	strcpy(num_str, input.c_str());
	strcpy(op_str, input.c_str());
}

void read_input_from_file() {
	ifstream read_file(PATH);
	if (read_file.is_open())
	{
		getline(read_file, input);
		read_file.close();
	}
}

int main()
{
	read_input_from_file();
	make_op_and_num_strings();
	fill_numbers_array();
	fill_operators_array();
	int res = calculate_all();
	write_result_into_file(res);
	cout << res;
}