# 📘 UML Diagram – Space Landing Game

* **ControlInput.cs** (שליטה בחללית)
* **GravityAdjustment.cs** (כבידה דינמית)
* **OnCollideWithObstacle.cs** (התנגשות → Game Over / Landing)

---

# 📦 Class Diagram (UML)

```mermaid\ classDiagram

    class ControlInput {
        +float thrustForce
        +float rotationForce
        -Rigidbody rb
        +Start()
        +FixedUpdate()
    }

    class GravityAdjustment {
        +Rigidbody rb
        +Transform planet
        +float gravityScale
        +Start()
        +FixedUpdate()
    }

    class OncollideWithObstacle {
        +GameObject obstacle
        +OnCollisionEnter(Collision)
    }

    %% Relationships
    ControlInput --> Rigidbody : uses
    GravityAdjustment --> Rigidbody : affects
    GravityAdjustment --> Transform : pulls toward planet
    OncollideWithObstacle --> GameObject : checks collision
```

---

# 📝 Class Descriptions

## **ControlInput.cs**

*Handles movement + rotation via keyboard input.*

**Responsibilities:**

* מוסיף כוח דחיפה (thrust)
* מסובב את הספינה עם torque

**Main Methods:**

* `Start()` – טוען Rigidbody
* `FixedUpdate()` – קורא קלט מקלדת ומיישם כוחות

---

## **GravityAdjustment.cs**

*Applies custom gravity pulling the ship toward the planet.*

**Responsibilities:**

* מחשב את כיוון המשיכה לכוכב
* מפעיל כוח כבידה פרופורציונלי למרחק

**Main Methods:**

* `Start()` – טוען Rigidbody + Planet
* `FixedUpdate()` – מחשב כוח משיכה ומושך את השחקן

---

## **OncollideWithObstacle.cs**

*Handles collisions with obstacles and the planet.*

**Responsibilities:**

* פגיעה במכשול → משמיד את הספינה
* פגיעה בכוכב → "נחיתה מוצלחת"

**Main Methods:**

* `OnCollisionEnter(Collision)` – בודק תגובה להתנגשות

---

# ✔ Notes

* כל המחלקות הן MonoBehaviour ולכן Unity קוראת להן אוטומטית.
* הכוחות פועלים בפיזיקה של Unity (Rigidbody).
* UML זה מייצג את מערכת הלוגיקה המרכזית של המשחק.

---

אם תרצה שאוסיף **ObstacleSpawner**, **DestroyWhenOutOfBounds** או **Restart**, רק תגיד ואעדכן את ה־UML! 🚀
