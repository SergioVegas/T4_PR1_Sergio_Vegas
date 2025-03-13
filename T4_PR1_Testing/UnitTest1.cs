using Xunit;
using T4._PR1._Practica_1.EnegyClass; // Asegúrate de tener la referencia correcta

public class SolarSystemTests
{
    [Fact]
    public void CalculateSolarEnergyCorrectEnergy()
    {
        // Arrange
        SolarSystem solarSystem = new SolarSystem { SunHours = 8, Rati = 0.5 };

        // Act
        double energy = solarSystem.CalculateEnergy();

        // Assert
        Assert.Equal(4, energy);
    }

    [Fact]
    public void CalculateSolarEnergyInCorrectEnergy()
    {
        // Arrange
        SolarSystem solarSystem = new SolarSystem { SunHours = 3.2, Rati = 1 };

        // Act
        double energy = solarSystem.CalculateEnergy();

        // Assert
        Assert.NotEqual(1, energy);
    }
}

public class WindSystemTests
{
    [Fact]
    public void CalculateWindEnergyCorrectEnergy()
    {
        // Arrange
        WindSystem windSystem = new WindSystem { WindVelocity = 5, Rati = 0.8 };

        // Act
        double energy = windSystem.CalculateEnergy();

        // Assert
        Assert.Equal(100, energy); // 5^3 * 0.8 = 100
    }

    [Fact]
    public void CalculateWindEnergyInCorrectEnergy()
    {
        // Arrange
        WindSystem windSystem = new WindSystem { WindVelocity = 2.5, Rati = 1 };

        // Act
        double energy = windSystem.CalculateEnergy();

        // Assert
        Assert.NotEqual(1, energy);
    }
    public class HidroelectricSystemTests
    {
        [Fact]
        public void CalculateHydroelectricEnergyCorrectEnergy()
        {
            // Arrange
            HidroelectricSystem hidroelectricSystem = new HidroelectricSystem { WaterFlow = 50, Rati = 0.8 };

            // Act
            double energy = hidroelectricSystem.CalculateEnergy();

            // Assert
            Assert.Equal(392, energy);
        }

        [Fact]
        public void CalculateHydroelectricEnergyInCorrectEnergy()
        {
            // Arrange
            HidroelectricSystem hidroelectricSystem = new HidroelectricSystem { WaterFlow = 25, Rati = 1 };

            // Act
            double energy = hidroelectricSystem.CalculateEnergy();

            // Assert
            Assert.NotEqual(1, energy);
        }
    }
}
