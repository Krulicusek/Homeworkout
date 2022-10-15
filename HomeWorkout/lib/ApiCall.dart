import 'dart:convert';
import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'models/ExerciseModel.dart';

class ApiCall {
  static String backendUrl = '';
  static String exerciseUrl = backendUrl + '';
  static Map<String, String> headers = {"Content-type": "application/json"};
  static String action;
  static List<ExerciseModel> mapProductTypes(String jsonString) {
    final parsed = json.decode(jsonString).cast<Map<String, dynamic>>();
    return parsed
        .map<ExerciseModel>((json) => ExerciseModel.fromJson(json))
        .toList();
  }

  static Future<List<ExerciseModel>> getExercises() async {
    action = '[GET ALL EXERCISES]';
    List<ExerciseModel> exercises;
    try {
      final response = await http.get(exerciseUrl);
      exercises =
          (json.decode(response.body) as List<dynamic>).cast<ExerciseModel>();
      debugPrint(exercises.isNotEmpty
          ? 'Subjects count: ${exercises.length}'
          : 'no subjects');
      debugPrint('$action request completed successfully');
      return exercises;
    } catch (e) {
      debugPrint('caught error: $e');
      return null;
    }
  }
}
