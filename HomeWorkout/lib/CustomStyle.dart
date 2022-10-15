import 'package:flutter/material.dart';

class CustomStyle {
  static Widget background() {
    return Container(
      decoration: BoxDecoration(
        gradient: LinearGradient(
          colors: [aiutDarkBlue(), aiutLightBlue()],
          begin: FractionalOffset.topCenter,
          end: FractionalOffset.bottomCenter,
        ),
      ),
    );
  }

  static Color aiutDarkBlue() {
    return Color.fromRGBO(8, 40, 99, 1);
  }

  static Color aiutDarkerBlue() {
    return Color.fromRGBO(7, 33, 82, 1);
  }

  static Color aiutLightBlue() {
    return Color.fromRGBO(130, 213, 255, 1);
  }

  static ShapeBorder myShapeBorder() {
    return RoundedRectangleBorder(borderRadius: BorderRadius.circular(15.0));
  }
}
