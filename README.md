# Parachute Simulation ✈️📦🎯

This Unity-based project is designed to simulate and validate the mechanics of precision airdrops, combining airplane control, parachute physics, and dynamic visual feedback. The goal is to create a realistic and interactive system where the accuracy of box drops into a target zone is influenced by multiple factors, such as:

- Aircraft speed (affects forward push and dispersion).
- Drop height (affects drift and parachute opening time).
- Wind dynamics (affects drift distance and drop accuracy).

https://github.com/user-attachments/assets/cf52fd6c-97e6-43bc-8ff1-e2ea2fc40cf7

## Features

### 1. **Airplane Control**

- The airplane follows a circular trajectory above the ground.
- Users can adjust:
  - **Speed**: Adjust rotational velocity using a slider.
  - **Height**: Modify the airplane's altitude using a slider.

### 2. **Box Deployment**

- Deploy boxes by pressing the **space key** when the airplane passes over the drop zone.
- Each box:
  - Opens its parachute at a randomized height.
  - Displays wind deviation and descent information during the drop.
- Real-time updates:
  - **Dispersion**: Distance between boxes dropped consecutively.
  - **Front Push**: Impact of airplane speed on box trajectory.

### 3. **Landing Accuracy**

- Landing feedback includes:
  - **Green laser**: Indicates when the airplane is above the target zone.
  - Box color changes:
    - **Green**: Landed in the target area.
    - **Red**: Missed the target area.

### 4. **Real-Time Visual Feedback**

- Display live updates on:
  - Airplane speed and height.
  - Dispersion between dropped boxes.
  - Calculated front push distance based on airplane speed.
- UI elements dynamically position themselves for an intuitive 3D view.

## User Interaction

- **Adjust airplane controls**:
  - Modify speed and height using sliders.
  - Observe how changes affect box deployment and accuracy.
- **Deploy boxes**:
  - Press the **space key** to drop boxes and aim for the target zone.
  - Track real-time feedback, including dispersion and front push.
- **Landing feedback**:
  - Green lasers guide alignment with the drop zone.
  - Box color changes provide immediate accuracy results.

## Calculations

### **1. Dispersion**

**Formula:**

```math
D = R \cdot T
```

**Explanation:**

- \(D\): Length of the drop zone (Z/L) required (in meters).
- \(R\): Speed of the aircraft (in meters per second).
- \(T\): Time required to drop the cargo.

**Conversion from knots to m/s:**

```math
m/s = \text{knots} \cdot 0.51
```

**Application:**
This formula calculates the length of the drop zone required for deploying a specific number of parachutists or boxes with minimal dispersion. Dispersion represents the lateral displacement of parachutists after the parachute opens.

**Example Calculation:**

- Aircraft speed: \(100 \, \text{knots}\).
- Time interval between drops: \(1 \, \text{s}\).
- Number of boxes: \(15\).

```math
D = (100 \cdot 0.51) \cdot 14
D = 46 \cdot 14
D = 644 \, \text{m}
```

### **2. Drift**

**Formula:**

```math
D = K \cdot A \cdot V
```

**Explanation:**

- \(D\): Drift distance of the parachute (in meters).
- \(K\): Constant representing drift characteristics of a specific parachute type:
  - \(1.5\): Cargo or heavy equipment parachute.
  - \(3.0\): Personnel parachute.
- \(A\): Drop height (in hundreds of feet SET).
- \(V\): Wind speed (in knots).

**Application:**
This formula calculates the parachute's drift due to wind. Drift is the horizontal displacement between the imaginary and actual impact points.

**Example Calculation:**

- Drop height: \(1250 \, \text{feet}\).
- Wind speed: \(3 \, \text{knots}\).
- Parachute type: Personnel (\(K = 3.0\)).

```math
D = 3.0 \cdot 12.5 \cdot 3
D = 112.5 \, \text{m}
```

### **3. Front Push**

**Formula:**

```math
E = V \cdot T
```

**Explanation:**

- \(E\): Front push distance (in meters).
- \(V\): Aircraft launch speed (in meters per second).
- \(T\): Time for the parachute to open (in seconds).

**Application:**
This formula calculates the front push experienced by the parachutist during the fall. Front push is the force acting in the direction opposite to the wind.

**Example Calculation:**

- Aircraft speed: \(100 \, \text{knots}\).
- Parachute opening time: \(4.30 \, \text{s}\).

```math
E = (100 \cdot 0.51) \cdot 4.30
E = 51 \cdot 4.30
E = 219.3 \, \text{m}
```

## **Parachute Opening Time Table**

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

> [!NOTE]
> This data was taken from the Colombian National Army Jumpmaster Manual

## License

This project is licensed under the MIT License.
