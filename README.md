# Parachute Simulation ✈️📦🎯

This Unity project is designed to simulate and validate the mechanics of precision airdrops, combining airplane control, parachute physics, and dynamic visual feedback. The goal is to create a realistic and interactive system where the accuracy of box drops into a target zone is influenced by multiple factors, such as:

- **Aircraft speed** (affects forward push and dispersion).
- **Drop height** (affects drift and parachute opening time).
- **Wind dynamics** (affects drift distance and drop accuracy).

https://github.com/user-attachments/assets/e5fbe09a-0f8b-454e-be5f-976c2cc10863

> [!NOTE]
> This simulation was created based on equations and data collected from the Colombian National Army Jumpmaster Manual.

## Features

### Airplane Control

- The airplane follows a circular trajectory above the ground.
- Users can adjust:
  - **Speed**: Adjust rotational velocity using a slider.
  - **Height**: Modify the airplane's altitude using a slider.

### Box Deployment

- Deploy boxes by pressing the **space key** when the airplane passes over the drop zone.
- Each box:
  - Opens its parachute at a randomized height.
  - Displays wind deviation and descent information during the drop.
- Real-time updates:
  - **Dispersion**: Distance between boxes dropped consecutively.
  - **Front Push**: Impact of airplane speed on box trajectory.

### Landing Accuracy

- Landing feedback includes:
  - **Green laser**: Indicates when the airplane is above the target zone.
  - Box color changes:
    - **Green**: Landed in the target area.
    - **Red**: Missed the target area.

### Real-Time Visual Feedback

- Display live updates on:
  - Airplane speed and height.
  - Dispersion between dropped boxes.
  - Calculated front push distance based on airplane speed.
- UI elements dynamically position themselves for an intuitive 3D view.

## Relevant data for calculations

### Parachute Drift Constant

| Drift Constant (K) | Parachute Type                     |
| ------------------ | ---------------------------------- |
| 1.5                | Cargo or heavy equipment parachute |
| 3.0                | Personnel parachute                |

### Parachute Opening Time

| **Aircraft Speed (Knots)** | **Minimum Time to Open (s)** | **Average Time to Open (s)** | **Maximum Time to Open (s)** |
| -------------------------- | ---------------------------- | ---------------------------- | ---------------------------- |
| 60                         | 5.30                         | 5.97                         | 6.50                         |
| 70                         | 4.53                         | 5.15                         | 5.87                         |
| 90                         | 3.95                         | 4.57                         | 5.29                         |
| 100                        | 3.68                         | 4.30                         | 5.02                         |
| 110                        | 3.18                         | 3.80                         | 4.52                         |
| 120                        | 2.90                         | 3.50                         | 4.10                         |
| 130                        | 2.80                         | 3.30                         | 3.90                         |
| 140                        | 2.30                         | 3.20                         | 4.10                         |
| 150                        | 2.30                         | 2.90                         | 3.70                         |

## Calculations

### Dispersion

**Equation:**

```math
D = R \cdot T
```

**Explanation:**

- \(D\): Length of the drop zone.
- \(R\): Speed of the aircraft.
- \(T\): Time required to drop the cargo.

**Application:**
This equation calculates the length of the drop zone required for deploying a specific number of parachutists or boxes with minimal dispersion. Dispersion represents the lateral displacement of parachutists after the parachute opens.

### Drift

**Equation:**

```math
D = K \cdot A \cdot V
```

**Explanation:**

- \(D\): Drift distance of the parachute.
- \(K\): Constant representing drift characteristics of a specific parachute type ([Parachute Drift Constant](#parachute-drift-constant)).
- \(A\): Drop height.
- \(V\): Wind speed.

**Application:**
This equation calculates the parachute's drift due to wind. Drift is the horizontal displacement between the imaginary and actual impact points.

### Front Push

**Equation:**

```math
E = V \cdot T
```

**Explanation:**

- \(E\): Front push distance.
- \(V\): Aircraft launch speed.
- \(T\): Time for the parachute to open ([Parachute Opening Time](#parachute-opening-time)).

**Application:**
This equation calculates the front push experienced by the parachutist during the fall. Front push is the force acting in the direction opposite to the wind.

## License

This project is licensed under the MIT License.
