import 'package:flutter/cupertino.dart';

class ExerciseModel {
  int id;
  String name;
  String tag;
  int numberOfTimes;
  bool isChoosen;
  int seconds;
  String imageSource;
  ExerciseModel(
      {this.id,
      this.name,
      this.tag,
      this.isChoosen,
      this.numberOfTimes,
      this.seconds,
      this.imageSource});
  ExerciseModel.manual(this.id, this.name, this.tag);

  factory ExerciseModel.fromJson(Map<String, dynamic> json) {
    return ExerciseModel(
        id: json['id'] as int,
        tag: json['tag'] as String,
        name: json['name'] as String,
        seconds: json['seconds'] as int,
        isChoosen: json['isChoosen'] as bool,
        numberOfTimes: json['isChoosen'] as int,
        imageSource: json['imageSource'] as String);
  }
}
