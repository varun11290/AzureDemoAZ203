package blobdemojava;

import java.util.Properties;
import java.io.IOException;
import java.io.InputStream;

public class Config {

    public static String GetPropertyValue(String property) {
        Properties prop = new Properties();

        InputStream propertyStream = BlobBasics.class.getClassLoader().getResourceAsStream("config.properties");
        if (propertyStream != null) {
            prop.load(propertyStream);
        } else {
            throw new RuntimeException();
        }

    }
}